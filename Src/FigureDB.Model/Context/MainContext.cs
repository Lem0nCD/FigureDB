using FigureDB.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FigureDB.Model.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistJob>().HasOne(x => x.Artist).WithMany(x => x.ArtistJobs);
            modelBuilder.Entity<ArtistJob>().HasOne(x => x.Job).WithMany(x => x.ArtistJobs);
            modelBuilder.Entity<Comment>().HasOne(x => x.User).WithMany(x => x.Comments);
            modelBuilder.Entity<Favorite>().HasOne(x => x.User).WithMany(x => x.Favorites);

            modelBuilder.Entity<FigureImage>().HasOne(x => x.Figure).WithMany(x => x.FigureImages);
            modelBuilder.Entity<FigureCategory>().HasOne(x => x.Category).WithMany(x => x.FigureCategories);
            modelBuilder.Entity<FigureCategory>().HasOne(x => x.Figure).WithMany(x => x.FigureCategories);
            modelBuilder.Entity<FigureSeries>().HasOne(x => x.Series).WithMany(x => x.FigureSeries);
            modelBuilder.Entity<FigureSeries>().HasOne(x => x.Figure).WithOne(x => x.FigureSeries).HasForeignKey<FigureSeries>(x => x.FigureId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FigureTag>().HasOne(x => x.Figure).WithMany(x => x.FigureTags);
            modelBuilder.Entity<FigureTag>().HasOne(x => x.Tag).WithMany(x => x.FigureTags);

            modelBuilder.Entity<Figure>().HasOne(x => x.Character).WithMany(x => x.Figures);
            modelBuilder.Entity<Figure>().HasOne(x => x.Publiced).WithMany(x => x.Publiceds);
            modelBuilder.Entity<Figure>().HasOne(x => x.Manufacturer).WithMany(x => x.Manufacturers);
            modelBuilder.Entity<Figure>().HasOne(x => x.Origin).WithMany(x => x.Figures);
            modelBuilder.Entity<News>().HasOne(x => x.Figure).WithMany(x => x.News);
            modelBuilder.Entity<News>().HasOne(x => x.User).WithMany(x => x.News);
            modelBuilder.Entity<Offer>().HasOne(x => x.Figure).WithMany(x => x.Offers);
            modelBuilder.Entity<Offer>().HasOne(x => x.Shop).WithMany(x => x.Offers);
            modelBuilder.Entity<UserIdentity>().HasOne(x => x.User).WithMany(x => x.UserIdentitys);
            modelBuilder.Entity<UserRole>().HasOne(x => x.User).WithOne(x => x.UserRole).HasForeignKey<UserRole>(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Shop>().HasOne(x => x.User).WithOne(x => x.Shop).HasForeignKey<Shop>(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistJob> ArtistJobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Figure> Figures { get; set; }
        public DbSet<FigureImage> FigureImages { get; set; }
        public DbSet<FigureCategory> FigureCategories { get; set; }
        public DbSet<FigureSeries> FigureSeries { get; set; }
        public DbSet<FigureTag> FigureTags { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserIdentity> UserIdentities { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
