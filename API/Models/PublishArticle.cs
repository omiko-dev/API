using API.Models.User;

namespace API.Models
{
    public class PublishArticle
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ArticleId { get; set; }
        public Article? Articles { get; set; }
        public bool Visibility { get; set; }

    }
}
