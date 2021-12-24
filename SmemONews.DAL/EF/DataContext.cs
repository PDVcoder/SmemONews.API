using Microsoft.EntityFrameworkCore;
using SmemONews.DAL.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SmemONews.DAL.EF
{
    public partial class DataContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<TagsInNews> NewsTags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<News>().Property(x => x.UserId).IsRequired(false);


            modelBuilder.Entity<User>().HasMany(w => w.Comments).WithOne(e => e.User).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<User>().HasMany(w => w.News).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Role>().HasMany(w => w.Users).WithOne(e => e.Role).HasForeignKey(e => e.RoleId).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<News>().HasMany(w => w.Comments).WithOne(e => e.News).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Role>().HasData(
            new Role[]
            {
                new Role{Id = 1, Name = "admin", Description = "Admin - it is main user, who have all right"},
                new Role{Id = 2, Name = "moderator", Description = "Moderator - it is user, whoc must check all news and publish it if all ok"},
                new Role{Id = 3, Name = "author", Description = "Author - it is user, who can create news"},
                new Role{Id = 4, Name = "guest", Description = "Guest - just visitor, who can view and comment news"}
            });

            //modelBuilder.Entity<Tag>().HasData(
            //new Tag[]
            //{
            //    new Tag{Id = 1, Name = "c++"},
            //    new Tag{Id = 2, Name = "java"},
            //    new Tag{Id = 3, Name = "c"},
            //    new Tag{Id = 4, Name = "csharp"},
            //    new Tag{Id = 5, Name = "js"},
            //    new Tag{Id = 6, Name = "javascript"},
            //    new Tag{Id = 7, Name = "html"},
            //    new Tag{Id = 8, Name = "css"}
            //});

            modelBuilder.Entity<Heading>().HasData(
            new Heading[]
            {
                new Heading {Id = 1, Name = "Education"},
                new Heading {Id = 2, Name = "Policy"},
                new Heading {Id = 3, Name = "Peoples"},
                new Heading {Id = 4, Name = "Ecology"},
                new Heading {Id = 5, Name = "IT"},
                new Heading {Id = 6, Name = "Medicine"},
                new Heading {Id = 7, Name = "Sport"},
                new Heading {Id = 8, Name = "Nature"},
                new Heading {Id = 9, Name = "Science"},
                new Heading {Id = 10, Name = "Society"},
                new Heading {Id = 11, Name = "Crime"}
            });
        }
    }
}
