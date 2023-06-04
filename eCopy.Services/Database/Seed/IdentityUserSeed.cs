using System.Linq;

namespace eCopy.Services.Database.Seed
{
    public static class IdentityUserSeed
    {
        public static void Seed(eCopyContext context)
        {
            if(!context.Users.Any(x => x.UserName == ""))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "cc",
                    Email = "cc",
                    NormalizedEmail = "cc".ToUpper(),
                    NormalizedUserName = "cc".ToUpper(),
                    PasswordHash = ""
                });
                context.SaveChanges();
            }
        }
    }
}
