namespace API.Models
{
    public class FullQuizModel
    {
        public int Id { get; set; }
        public List<QuizModel> Quiz { get; set; } = new List<QuizModel>();
        public string Title { get; set; } = string.Empty;
    }
}
