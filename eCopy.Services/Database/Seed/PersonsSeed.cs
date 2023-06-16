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
            if (!context.Persons.Any(x => x.FirstName == "cliuser"))
            {
                context.Persons.Add(new Person
                {
                    FirstName = "cliuser",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    LastName = "cliuser",
                    MiddleName = "cliuser",
                    Gender = "Male",
                    CityId = 1,
                    Address = "adress",
                    BirthDate = DateTime.Now
                });
            }
            if (!context.Persons.Any(x => x.FirstName == "cliuser2"))
            {
                context.Persons.Add(new Person
                {
                    FirstName = "cliuser2",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    LastName = "cliuser2",
                    MiddleName = "cliuser2",
                    Gender = "Male",
                    CityId = 1,
                    Address = "adress",
                    BirthDate = DateTime.Now
                });
            }
            if (!context.Persons.Any(x => x.FirstName == "cliuser3"))
            {
                context.Persons.Add(new Person
                {
                    FirstName = "cliuser3",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    LastName = "cliuser3",
                    MiddleName = "cliuser3",
                    Gender = "Male",
                    CityId = 1,
                    Address = "adress",
                    BirthDate = DateTime.Now
                });
            }
            if (!context.Persons.Any(x => x.FirstName == "cliuser4"))
            {
                context.Persons.Add(new Person
                {
                    FirstName = "cliuser4",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    LastName = "cliuser4",
                    MiddleName = "cliuser4",
                    Gender = "Male",
                    CityId = 1,
                    Address = "adress",
                    BirthDate = DateTime.Now
                });
            }

            if (!context.Persons.Any(x => x.FirstName == "cliuser5"))
            {
                context.Persons.Add(new Person
                {
                    FirstName = "cliuser5",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    LastName = "cliuser5",
                    MiddleName = "cliuser5",
                    Gender = "Male",
                    CityId = 1,
                    Address = "adress",
                    BirthDate = DateTime.Now
                });
            }
            if (!context.Persons.Any(x => x.FirstName == "emp2"))
            {
                context.Persons.Add(new Person
                {
                    FirstName = "emp2",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    LastName = "emp2",
                    MiddleName = "Middle name",
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
