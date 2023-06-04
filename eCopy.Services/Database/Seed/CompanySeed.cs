using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class CompanySeed
    {
        public static void Seed(eCopyContext context)
        {
            if(!context.Companies.Any(x => x.Name == "MoCompany"))
            {
                context.Companies.Add(new Company
                {
                    CreatedDate =  DateTime.Now, 
                    ModifiedDate = null,
                    Active = true,
                    Name = "MoCompany",
                    ContactAgent = "AgentName", 
                    Jib = "123",
                    PhoneNumber = "0123456", 
                    Email = "agentname@hotmail.com",
                    Address = "Mostar",
                    CityId = 1,
                });
                context.SaveChanges();
            }
        }
    }
}
