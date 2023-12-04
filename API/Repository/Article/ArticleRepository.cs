using API.Data;

namespace API.Repository.Article
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly UserDbContext userDb;

        public ArticleRepository(UserDbContext userDb)
        {
            this.userDb = userDb;
        }

        public ICollection<Models.User.Article> getAllArticles()
        {
            var articles = userDb.Articles.ToList();

            return articles;
        }
    }
}
