using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class PersonsSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Persons.Any(x => x.FirstName == "emp"))
            {
                context.Persons.Add(new Person
                {
                    FirstName = "emp",
                    CreatedDate = DateTime.Now,
                    ModifiedDate= null,
                    Active= true,
                    LastName = "emp",
                    MiddleName = "Middle name",
                    Gender = "Male",
                    CityId = 1,
                    Address = "adress",
                    BirthDate = DateTime.Now
                });
            }
            if (!context.Persons.Any(x => x.FirstName == "cli"))
            {
                context.Persons.Add(new Person
                {
                    FirstName = "cli",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    LastName = "cli",
                    MiddleName = "cli",
                    Gender = "Male",
                    CityId = 1,
                    Address = "adress",
                    BirthDate = DateTime.Now
                });
            }
            if (!context.Persons.Any(x => x.FirstName == "adm"))
            {
                context.Persons.Add(new Person
                {
                    FirstName = "adm",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    LastName = "adm",
                    MiddleName = "adm",
                    Gender = "Male",
                    CityId = 1,
                    Address = "adress",
                    BirthDate = DateTime.Now
                });
            }
            context.SaveChanges();
        }
    }
}
