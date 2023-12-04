using API.Data;
using API.Models;
using API.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.User
{

    [Authorize(Roles = "user")]
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext userDb;

        public UserRepository(UserDbContext userDb)
        {
            this.userDb = userDb;
        }

        

        public async Task<Models.User.Article> AddArticle(Models.User.Article article, string email)
        {
            var user = getUser(email);
            if (user == null)
                return null!;

            await userDb.Articles.AddAsync(article);
            await userDb.SaveChangesAsync();

            return article;

        }

        public async Task<Models.User.Article> DeleteArticle(Models.User.Article article, string email)
        {
            var user = getUser(email);
            if (user == null)
                return null!;

            userDb.Articles.Remove(article); 
            await userDb.SaveChangesAsync();

            return article;
        }

        public ICollection<Models.User.Article> GetArticles()
        {
            throw new NotImplementedException();
        }

        public Models.User.User GetUser(string email)
        {
            var user = userDb.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
                return null!;
            return user;
        }

        public async Task<PublishArticle> PublishArticle(Models.User.Article article, string email)
        {
            var user = await getUser(email);
            if (user == null)
                return null!;

            var publicArticle = new PublishArticle
            {
                Id = 0,
                Name = user.Name,
                Articles = article,
                ArticleId = article.ArticleId,
                Visibility = false
            };

            await userDb.PublishArticles.AddAsync(publicArticle);
            await userDb.SaveChangesAsync();
            return publicArticle;
        }

        public async Task<Models.User.Article> UpdateArticle(Models.User.Article article, string email)
        {
            var user = await getUser(email);
            if (user == null)
                return null!;

            var art = user!.Articles!.FirstOrDefault(i => i.ArticleId == article.ArticleId);

            art = article;
            await userDb.SaveChangesAsync();

            return article;
        }


        private async Task<Models.User.User?> getUser(string Email) => await userDb.Users.FirstOrDefaultAsync(u => u.Email == Email);
    }
}