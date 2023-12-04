namespace API.Models.User
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Describtion { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public int likeCount { get; set; }
    }
}
