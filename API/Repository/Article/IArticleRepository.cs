

namespace API.Repository.Article
{
    public interface IArticleRepository
    {

        public ICollection<Models.User.Article> getAllArticles();

    }
}
