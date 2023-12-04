namespace API.Models
{
    public class QuizModel
    {

        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Description { get; set; } =  string.Empty;
        public Dictionary<int, string> Answer { get; set; } = new Dictionary<int, string>();
        public int correctQuestionId { get; set; }

    }
}
