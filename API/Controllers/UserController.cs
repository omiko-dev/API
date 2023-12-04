using API.Models.User;
using API.Repository.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user")]
    public class UserController : ControllerBase
    {
        public UserController(IUserRepository repository)
        {
            Repository = repository;
        }

        public IUserRepository Repository { get; }

        [HttpPost("publish")]
        public async Task<IActionResult> publishArticle([FromBody] Article article)
        {
            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var user = await Repository.PublishArticle(article, email);

            return Ok(user);
        }

        [HttpGet("getUser")]
        public async Task<IActionResult> getMe()
        {
            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var user = Repository.GetUser(email);
            if (user == null)
                return BadRequest("error");

            return Ok(user);
        }
    }
}
