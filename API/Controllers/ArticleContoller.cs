using API.Repository.Article;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleContoller : ControllerBase
    {
        private readonly IArticleRepository repository;

        public ArticleContoller(IArticleRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticle()
        {
            var articles = repository.getAllArticles();
            return Ok(articles);
        }



    }
}
