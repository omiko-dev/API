using API.Repository.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository repository;

        public AdminController(IAdminRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> getAllArtice()
        {
            var articles = repository.getAllArticle();

            return Ok(articles);
        }



    }
}
