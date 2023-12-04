using API.Models;
using API.Models.User;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Navigation(u => u.Articles).AutoInclude();
            modelBuilder.Entity<PublishArticle>()
                .HasOne(p => p.Articles)  
                .WithMany()
                .HasForeignKey(p => p.ArticleId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; database=User_Hackaton; Trusted_Connection=true; MultipleActiveResultSets=true; Integrated Security=true;");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<PublishArticle> PublishArticles { get; set; }


    }
}
