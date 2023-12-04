using API.Repository.Statistic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticRepository repository;

        public StatisticController(IStatisticRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllItem()
        {
            return Ok(repository.GetAllStatisticItem());
        }


        [HttpGet("id")]
        public IActionResult GetItemById(int id)
        {
            return Ok(repository.GetStatisticItem(id));
        }



    }
}
