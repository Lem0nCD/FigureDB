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
            modelBuilder.Entity<ArtistJob>().HasOne(x => x.Artist).WithMany(x => x.ArtistJobs).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ArtistJob>().HasOne(x => x.Job).WithMany(x => x.ArtistJobs).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>().HasOne(x => x.User).WithMany(x => x.Comments).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Favorite>().HasOne(x => x.User).WithMany(x => x.Favorites).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FigureImage>().HasOne(x => x.Figure).WithMany(x => x.FigureImages).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FigureImage>().HasOne(x => x.Image).WithMany(x => x.FigureImages).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FigureTag>().HasOne(x => x.Figure).WithMany(x => x.FigureTags).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FigureTag>().HasOne(x => x.Tag).WithMany(x => x.FigureTags).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Figure>().HasOne(x => x.Character).WithMany(x => x.Figures).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Figure>().HasOne(x => x.Origin).WithMany(x => x.Figures).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Figure>().HasOne(x => x.Published).WithMany(x => x.Publiceds).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Figure>().HasOne(x => x.Manufacturer).WithMany(x => x.Manufacturers).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Figure>().HasOne(x => x.Series).WithMany(x => x.Figures).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Figure>().HasOne(x => x.FigureType).WithOne(x => x.Figure).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FigureType>().HasOne(x => x.Figure).WithOne(x => x.FigureType).HasForeignKey<FigureType>(x => x.FigureId) .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<News>().HasOne(x => x.Figure).WithMany(x => x.News).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Offer>().HasOne(x => x.Figure).WithMany(x => x.Offers).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Offer>().HasOne(x => x.Shop).WithMany(x => x.Offers).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Recommand>().HasOne(x => x.Figure).WithMany(x => x.Recommands).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Recommand>().HasOne(x => x.Image).WithOne(x => x.Recommand).HasForeignKey<Recommand>(x => x.ImageId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserIdentity>().HasOne(x => x.User).WithMany(x => x.UserIdentitys).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Shop>().HasOne(x => x.User).WithOne(x => x.Shop).HasForeignKey<Shop>(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistJob> ArtistJobs { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Figure> Figures { get; set; }
        public DbSet<FigureImage> FigureImages { get; set; }
        public DbSet<FigureTag> FigureTags { get; set; }
        public DbSet<FigureType> FigureTypes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Recommand> Recommands { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserIdentity> UserIdentities { get; set; }
    }
}
