using AutoMapper;
using eCopy.Model;
using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace eCopy.Services
{
    public class EmployeeServicee: BaseCRUDService<EmployeeResponse, Employee, EmployeeSearch, EmployeeRequest, EmployeeRequest>, IEmployeeService
        
    {
        private readonly IFileService fileService;
        private readonly IUserService userService;
        private IHttpContextAccessor httpContextAccessor;
        private readonly IPasswordHasher<Database.IdentityUser> hasher;

        public EmployeeServicee(eCopyContext context, IMapper mapper, IFileService fileService,
            IUserService userService, IHttpContextAccessor httpContextAccessor, IPasswordHasher<Database.IdentityUser> hasher) 
            : base(context, mapper)
        {
            this.fileService = fileService;
            this.userService = userService;
            this.httpContextAccessor = httpContextAccessor;
            this.hasher = hasher;
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
                profilePhoto.Name = uploadedFile.Name;
                profilePhoto.Extension = uploadedFile.Extension;

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

        public override void Delete(int id)
        {
            var employee = context.Employees.Find(id);
            var person = context.Persons.Find(employee.PersonId);
            var user = context.Users.Find(employee.ApplicationUserId);
            var userRoles = context.UserRoles.Where(x => x.UserId == user.Id).ToList();
            var profilePhtotos = context.ApplicationUserProfilePhotos.Where(x=> x.ApplicationUserId == user.Id).ToList();

            context.Employees.Remove(employee);
            context.Persons.Remove(person);
            context.ApplicationUserProfilePhotos.RemoveRange(profilePhtotos);
            context.UserRoles.RemoveRange(userRoles);
            context.Users.Remove(user);
           
            context.SaveChanges();

        }

        public EmployeeResponse UpdateEmp(UpdateEmployeeRequest update)
        {
            var employeeIdClaim = httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "EmployeeId");

            var employeeId = int.Parse(employeeIdClaim.Value);

            var emp = context.Employees
                .Include(x => x.ApplicationUser)
                .Include(x => x.Person)
                .FirstOrDefault(x => x.Id == employeeId);

            emp.Person.FirstName= update.FirstName;
            emp.Person.LastName = update.LastName;
            emp.Person.MiddleName = update.MiddleName;
            emp.Person.Gender = update.Gender.ToString();
            emp.Person.CityId = update.CityId;
            emp.Person.Address = update.Address;
            emp.Person.BirthDate = update.BirthDate;

            emp.ApplicationUser.Active = true;
            emp.Active = update.Active;
            emp.ApplicationUser.NormalizedEmail = update.Email.ToUpper();
            emp.ApplicationUser.Email = update.Email;
            emp.ApplicationUser.UserName = update.Username;
            emp.ApplicationUser.NormalizedUserName = update.Username.ToUpper();
            emp.ApplicationUser.PhoneNumber = update.PhoneNumber;

            ProfilePhoto profilePhoto = null;
            if (update.ProfilePhoto != null)
            {
                var uploadedFile = fileService.Upload(update.ProfilePhoto, update.ProfilePhotoExtension);

                profilePhoto = new ProfilePhoto();
                profilePhoto.Active = true;
                profilePhoto.Path = uploadedFile.Url;
                profilePhoto.Name = uploadedFile.Name;
                profilePhoto.Extension = uploadedFile.Extension;

                context.ProfilePhotos.Add(profilePhoto);
                context.SaveChanges();
            }
            
            if (profilePhoto != null)
            {
                var userProfilePhoto = new ApplicationUserProfilePhoto
                {
                    ApplicationUserId = emp.ApplicationUser.Id, 
                    ProfilePhotoId = profilePhoto.Id,
                    Active = true
                };
                context.ApplicationUserProfilePhotos.Add(userProfilePhoto);
            }

            context.SaveChanges();

            return mapper.Map<EmployeeResponse>(emp);

        }

        public EmployeeResponse GetEmployeeAccount()
        {
            var employeeIdClaim = httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "EmployeeId");

            var employeeId = int.Parse(employeeIdClaim.Value);

            var empuser = context.Employees
                .Include(x => x.ApplicationUser)
                .ThenInclude(x => x.ApplicationUserProfilePhotos)
                .ThenInclude(x => x.ProfilePhoto)
                .Include(x => x.Person)
                .ThenInclude(x => x.City)
                .FirstOrDefault(x => x.Id == employeeId);


            return mapper.Map<EmployeeResponse>(empuser);
        }

        public bool ChangePass(PassRequest request)
        {
            var employeeIdClaim = httpContextAccessor.HttpContext.User.Claims
              .FirstOrDefault(x => x.Type == "EmployeeId");
            var employeeId = int.Parse(employeeIdClaim.Value);

            var employee = context.Employees
                .Include(x => x.ApplicationUser)
            .FirstOrDefault(x => x.Id == employeeId);

            if (hasher.VerifyHashedPassword(employee.ApplicationUser, employee.ApplicationUser.PasswordHash, request.oldPass) != PasswordVerificationResult.Success)
            {
                return false;
            }

            employee.ApplicationUser.PasswordHash = hasher.HashPassword(employee.ApplicationUser, request.newPass);

            context.SaveChanges();

            return true;
        }

    }
}
