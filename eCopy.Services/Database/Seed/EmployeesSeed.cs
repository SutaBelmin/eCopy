using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class EmployeesSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Employees.Any(x => x.Active == true))
            {
                context.Employees.Add(new Employee
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    PersonId = 1,
                    CopierId = 1,
                    ApplicationUserId = 2                    
                });
                context.SaveChanges();
            }
        }
    }
}
