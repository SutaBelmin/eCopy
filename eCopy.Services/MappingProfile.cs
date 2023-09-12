using AutoMapper;
using eCopy.Model;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Services.Database;
using System.Linq;

namespace eCopy.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeResponse, Employee>()
                .ReverseMap()
                .ForMember(x=> x.ProfilePhotoPath, opt =>
                opt.MapFrom(x=> x.ApplicationUser.ApplicationUserProfilePhotos.Any() ? x.ApplicationUser.ApplicationUserProfilePhotos.FirstOrDefault().ProfilePhoto.Path : null));

            CreateMap<EmployeeRequest, Employee>()
                .ForMember(x => x.Person, opt => opt.Ignore())
                .ForMember(x => x.ApplicationUser, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CopierResponse, Copier>().ReverseMap();
            CreateMap<CopierRequest, Copier > ().ReverseMap();

            CreateMap<PersonResponse, Person>().ReverseMap();
            CreateMap<PersonRequest, Person>().ReverseMap();

            CreateMap<ApplicationUserRequest, Database.IdentityUser>().ReverseMap();


            CreateMap<PrintRequest, Request>().ReverseMap();
            CreateMap<PrintRequestR, Request>()
                .ReverseMap()
                .ForMember(x => x.ClientName, opt => opt.MapFrom(x => x.Client != null && x.Client.Person != null ? string.Concat(x.Client.Person.FirstName, " ", x.Client.Person.LastName) : null));
            CreateMap<PrintRequestUpdate, Request>().ReverseMap();

            CreateMap<Request, UpdateRequest>().ReverseMap();
            CreateMap<PrintRequestR, UpdateRequest>().ReverseMap();



            CreateMap<CityRequest, City>().ReverseMap();
            CreateMap<CityResponse, City>().ReverseMap();

            CreateMap<EmployeeRequest, ProfilePhoto>()
                .ForMember(x=> x.SizeInBytes, opt => opt.MapFrom(x => x.ProfilePhoto.Length))
                .ForMember(x=> x.Extension, opt => opt.MapFrom(x => x.ProfilePhotoExtension))
                .ForMember(x=> x.Name, opt => opt.MapFrom(x => x.ProfilePhotoName))
                .ReverseMap();


            CreateMap<ClientRequest, Client>().ReverseMap();
            CreateMap<ClientResponse, Client>().ReverseMap();

            CreateMap<ClientRequestUpdate, Client>().ReverseMap();


            CreateMap<ApplicationUserResponse, Database.IdentityUser>().ReverseMap();

            CreateMap<ErrorRequest, Error>().ReverseMap();




            CreateMap<LetterRequest, Letter>().ReverseMap();
            CreateMap<LetterResponse, Letter>().ReverseMap();
            CreateMap<LetterRequestUpdate, Letter>().ReverseMap();

            CreateMap<OrientationRequest, Orientation>().ReverseMap();
            CreateMap<OrientationResponse, Orientation>().ReverseMap();
            CreateMap<OrientationRequestUpdate, Orientation>().ReverseMap();

            CreateMap<CollatedRequest, CollatedPrintOption>().ReverseMap();
            CreateMap<CollatedResponse, CollatedPrintOption>().ReverseMap();
            CreateMap<CollatedRequestUpdate, CollatedPrintOption>().ReverseMap();

            CreateMap<SideRequest, SidePrintOption>().ReverseMap();
            CreateMap<SideResponse, SidePrintOption>().ReverseMap();
            CreateMap<SideRequestUpdate, SidePrintOption>().ReverseMap();

            CreateMap<PrintPageOptionRequest, PrintPageOption>().ReverseMap();
            CreateMap<PrintPageOptionResponse, PrintPageOption>().ReverseMap();
            CreateMap<PrintPageOptionRequestUpdate, PrintPageOption>().ReverseMap();

            CreateMap<PagePerSheetRequest, PagePerSheet>().ReverseMap();
            CreateMap<PagePerSheetResponse, PagePerSheet>().ReverseMap();
            CreateMap<PagePerSheetRequestUpdate, PagePerSheet>().ReverseMap();


        }
    }
}
