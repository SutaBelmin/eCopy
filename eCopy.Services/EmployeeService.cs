using AutoMapper;
using eCopy.Model;
using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.SearchObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{
    public class EmployeeServicee: BaseCRUDService<EmployeeResponse, Employee, EmployeeSearch, EmployeeRequest, EmployeeRequest>, IEmployeeService
        
    {
        private readonly IFileService fileService;
        private readonly IUserService userService;

        public EmployeeServicee(eCopyContext context, IMapper mapper, IFileService fileService,
            IUserService userService) 
            : base(context, mapper)
        {
            this.fileService = fileService;
            this.userService = userService;
        }

       public override IEnumerable<EmployeeResponse> Get(EmployeeSearch search = null)
        {
          
            var entity = context.Employees.AsQueryable();

            entity = AddFilter(entity, search);

            var list = entity
                .Include(x => x.ApplicationUser)
                .ThenInclude(x =>x.ApplicationUserProfilePhotos)
                .ThenInclude(x =>x.ProfilePhoto)
                .Include(x => x.Person)
                .Include(y => y.Copier)
                .ToList();

            return mapper.Map<IList<EmployeeResponse>>(list);

        }
        public override EmployeeResponse GetById(int id)
        {
            var entity = context.Employees.AsQueryable();

            var emp = entity
                .Include(x => x.ApplicationUser)
                .ThenInclude(x => x.ApplicationUserProfilePhotos)
                .ThenInclude(x => x.ProfilePhoto)
                .Include(x => x.Person)
                .Include(y => y.Copier)
                .FirstOrDefault(x=> x.Id == id);

            return mapper.Map<EmployeeResponse>(emp);
        }

        public override IQueryable<Employee> AddFilter(IQueryable<Employee> query, EmployeeSearch search = null)
        {

            query = query
                .Include(x => x.Person)
                .Include(y => y.Copier);

            if (!string.IsNullOrWhiteSpace(search?.FirstName))
            {
                query = query.Where(x => x.Person.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(search?.LastName))
            {
                query = query.Where(x => x.Person.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            return query;
        }

        public override EmployeeResponse Insert(EmployeeRequest entity)
        {
            using var transaction = context.Database.BeginTransaction();
            Employee model = mapper.Map<Employee>(entity);

            ProfilePhoto profilePhoto = null;
            if (entity.ProfilePhoto != null)
            {
                var uploadedFile = fileService.Upload(entity.ProfilePhoto, entity.ProfilePhotoExtension);

                profilePhoto = mapper.Map<ProfilePhoto>(entity);
                profilePhoto.Active = true;
                profilePhoto.Path = uploadedFile.Url;

                context.ProfilePhotos.Add(profilePhoto);
            }

            entity.User.Role = Role.Employee;
            var user = userService.Insert(entity.User);

            if (profilePhoto != null)
            {
                var userProfilePhoto = new ApplicationUserProfilePhoto
                {
                    ApplicationUserId = user.Id,
                    ProfilePhotoId = profilePhoto.Id,
                    Active = true
                };
                context.ApplicationUserProfilePhotos.Add(userProfilePhoto);
            }

            var person = mapper.Map<Person>(entity.Person);
            person.Active = entity.Active;
            context.Persons.Add(person);

            context.SaveChanges();

            model.ApplicationUserId = user.Id;
            model.PersonId = person.Id;

            context.Employees.Add(model);
            context.SaveChanges();

            transaction.Commit();
            return mapper.Map<EmployeeResponse>(model);
        }


        public override EmployeeResponse Update(int id, EmployeeRequest entity)
        {
            var employee = context.Employees.Find(id);
            mapper.Map(entity, employee);

            var person = context.Persons.Find(employee.PersonId);
            mapper.Map(entity.Person, person);

            var user = context.Users.Find(employee.ApplicationUserId);
            mapper.Map(user, employee.ApplicationUser);

            context.SaveChanges();

            return mapper.Map<EmployeeResponse>(employee);
        }

    }
}
