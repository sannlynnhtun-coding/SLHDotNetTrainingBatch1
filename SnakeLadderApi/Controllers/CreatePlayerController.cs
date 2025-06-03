using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnakeLadderApi.Models.CreatePlayer;
using SnakeLadderApi.Services.CreatePlayerService;

namespace SnakeLadderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatePlayerController : ControllerBase
    {
        private readonly CreatePlayerService _createPlyerService;

        public CreatePlayerController(CreatePlayerService createPlyerService)
        {
            _createPlyerService = createPlyerService;
        }

        [HttpPost]
        public IActionResult CreatePlayer([FromBody] CreateRequestModel requestModel)
        {
            var model = _createPlyerService.CreatePlayer(requestModel);

            return Ok(model);
        }

        
    }
}
