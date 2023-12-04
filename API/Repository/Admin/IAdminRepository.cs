using API.Models;

namespace API.Repository.Admin
{
    public interface IAdminRepository
    {

        public List<PublishArticle> getAllArticle();

        public List<PublishArticle> PublicArticle();

        public List<PublishArticle> getPrivateArticles();

    }
}
