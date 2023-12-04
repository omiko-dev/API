using API.Models;
using API.Models.User;

namespace API.Repository.User
{
    public interface IUserRepository
    {

        public API.Models.User.User GetUser(string email);
        public ICollection<Models.User.Article> GetArticles();
        public Task<Models.User.Article> AddArticle(Models.User.Article article, string email);
        public Task<Models.User.Article> UpdateArticle(Models.User.Article article, string email);
        public Task<Models.User.Article> DeleteArticle(Models.User.Article article, string email);
        public Task<PublishArticle> PublishArticle(Models.User.Article article, string UserName);
    }
}
