namespace API.Models.User
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int Point { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Rank { get; set; } = string.Empty;

        public ICollection<Article>? Articles { get; set; }

    }
}
