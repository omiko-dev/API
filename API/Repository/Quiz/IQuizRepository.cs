using API.Models;

namespace API.Repository.Quiz
{
    public interface IQuizRepository
    {

        public FullQuizModel GetQuizModel(int id);

        public List<FullQuizModel> GetAllQuizModels();

    }
}
