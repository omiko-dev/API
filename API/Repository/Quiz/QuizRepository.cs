using API.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Repository.Quiz
{
    public class QuizRepository : IQuizRepository
    {
        static private List<QuizModel> quiz1 = new List<QuizModel>
        {
            new QuizModel
            {
                Id = 1,
                Question = "დეკოდირების მედია ყველაზე მეტად ჰგავს:",
                Description = "Test",
                Answer =
                {
                    {1, "ა) წიგნების კითხვას"},
                    {2, "ბ) ექსპერიმენტის ჩატარებას"},
                    {3, "გ) საიდუმლოს ამოხსნას"},
                    {4, "დ) საჭმლის მომზადებას"}
                },
                correctQuestionId = 3
            },
            new QuizModel
            {
                Id = 2,
                Question = "ჩამოთვლილთაგან რომელია „მედია“?",
                Description = "Test",
                Answer =
                {
                    {1, "ა)ტელევიზია, ფილმები, ჟურნალები, გაზეთები, ვიდეო თამაშები, მუსიკა, რადიო და რეკლამა"},
                    {2, "ბ)სოციალური ქსელები, ფოტოების და ვიდეოების გაზიარების ვებსაიტები და სხვა ონლაინ შინაარსი"},
                    {3, "გ)არაზუსტი ინფორმაცია"},
                    {4, "გ)ორივე ა და ბ "}
                },
                correctQuestionId = 4
            },
            new QuizModel
            {
                Id =3,
                Question = "სიტყვა „წერა-კითხვა“ მედიაწიგნიერებაში აღნიშნავს:",
                Description = "Test",
                Answer =
                {
                    {1, "ა) ჩემი ლექსიკის გაუმჯობესება"},
                    {2, "ბ) მნიშვნელობისა და შეტყობინებების გააზრება"},
                    {3, "გ) კითხულობს ტექნოლოგიას"},
                    {4, "დ) ისწავლეთ უფრო სწრაფად კითხვა"}
                },
                correctQuestionId = 4
            },
            new QuizModel
            {
                Id = 4,
                Question = "რომელ ტერმინს ვუწოდებთ მედიაში გავხელებულ ცრუ ინფორმაციას?",
                Description = "Test",
                Answer =
                {
                    {1, "ა) პროპაგანდა"},
                    {2, "ბ) სატირა"},
                    {3, "ბ) დეზინფორმაცია"},
                    {4, "დ) Გასართობი"}
                },
                correctQuestionId = 3
            },
            new QuizModel
            {
                Id = 5,
                Question = "რა არის \"ClickBait\"?",
                Description = "Test",
                Answer =
                {
                    {1, "კონტენტს, რომლის სათაური შეცვლილია შეცდომაში შეყვანის მიზნით"},
                    {2, "გრძელვადიანი საგამოძიებო ჟურნალისტიკა"},
                    {3, "კონტენტი, რომელიც ხელმისაწვდომია მხოლოდ ფასიანი გამოწერებით"},
                    {4, "გადამოწმებული და ზუსტი ახალი სტატიები"}
                },
                correctQuestionId = 1
            }
        };

        private List<FullQuizModel> allQuize = new List<FullQuizModel>
        {
            new FullQuizModel
            {
                Id = 1,
                Quiz = quiz1,
                Title = "one"
            },
            new FullQuizModel
            {
                Id = 2,
                Quiz = quiz1,
                Title = "one"
            },
            new FullQuizModel
            {
                Id = 3,
                Quiz = quiz1,
                Title = "one"
            },
            new FullQuizModel
            {
                Id = 4,
                Quiz = quiz1,
                Title = "one"
            },
        };

        public List<FullQuizModel> GetAllQuizModels()
        {
            return allQuize;
        }

        public FullQuizModel GetQuizModel(int id)
        {
            return allQuize.Find(match: i => i.Id == id)!;
        }
    }
}
