using Demo_Mock_House_Finder.Model;
using Microsoft.EntityFrameworkCore;
namespace Demo_Mock_House_Finder.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Commune> Communes { get; set; }
        public DbSet<Village> Villages { get; set; }
         
        public DbSet<Status> Statuses { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms {  get; set; } 
        public DbSet<Rate> Rates { get; set; }
        public DbSet<HouseImage> HouseImages { get; set; }
        public DbSet<RoomImage> Roomimages { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<RoomHistory> RoomHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>()
                        .HasOne(h => h.Landlord)
                        .WithMany(u => u.Houses)
                        .HasForeignKey(h => h.LandlordID);
            modelBuilder.Entity<House>()
                        .HasOne(h => h.Landlord)
                        .WithMany()
                        .HasForeignKey(h => h.CreatedBy);
            modelBuilder.Entity<House>()
                        .HasOne(h => h.Landlord)
                        .WithMany()
                        .HasForeignKey(h => h.LastModifiedBy);
        }
    }
}
