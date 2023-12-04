using API.Data;
using API.Models;

namespace API.Repository.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly UserDbContext userDb;

        public AdminRepository(UserDbContext userDb)
        {
            this.userDb = userDb;
        }

        public List<PublishArticle> getAllArticle()
        {
            var users = userDb.PublishArticles.ToList();

            return users;
        }

        public List<PublishArticle> getPrivateArticles()
        {
            throw new NotImplementedException();
        }

        public List<PublishArticle> PublicArticle()
        {
            throw new NotImplementedException();
        }
    }
}
