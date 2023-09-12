using eCopy.Services.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCopy.Services
{
    public partial class eCopyContext : IdentityDbContext<Database.IdentityUser, Database.IdentityRole, int, IdentityUserClaim, IdentityUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken>
    {
        public eCopyContext()
        {
        }

        public eCopyContext(DbContextOptions<eCopyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<ApplicationUserProfilePhoto> ApplicationUserProfilePhotos { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Copier> Copiers { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<PrintRequestFile> PrintRequestFiles { get; set; } = null!;
        public virtual DbSet<ProfilePhoto> ProfilePhotos { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<Error> Errors { get; set; } = null!;
        public virtual DbSet<Payment> Payment { get; set; } = null!;
        public virtual DbSet<Letter> Letter { get; set; } = null!;
        public virtual DbSet<PagePerSheet> PagePerSheet { get; set; } = null!;
        public virtual DbSet<CollatedPrintOption> CollatedPrintOption { get; set; } = null!;
        public virtual DbSet<Orientation> Orientation { get; set; } = null!;
        public virtual DbSet<SidePrintOption> SidePrintOption { get; set; } = null!;
        public virtual DbSet<PrintPageOption> PrintPageOption { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Model
                .GetEntityTypes()
                .ToList()
                .ForEach(x =>
                    x
                    .GetForeignKeys()
                    .ToList()
                    .ForEach(y => y.DeleteBehavior = DeleteBehavior.Restrict)
                );

            builder.Entity<IdentityUserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.AspNetUserRoles)
                .HasForeignKey(x => x.RoleId);

            builder.Entity<IdentityUserRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.AspNetUserRoles)
                .HasForeignKey(x => x.UserId);

        }
    }
}
