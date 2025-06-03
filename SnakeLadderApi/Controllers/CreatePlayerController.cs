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
        private readonly CreatePlyerService _createPlyerService;

        public CreatePlayerController(CreatePlyerService createPlyerService)
        {
            _createPlyerService = createPlyerService;
        }

        [HttpPost]
        public IActionResult CreatePlayer([FromBody] CreateRequestModel requestModel)
        {
            var model = _createPlyerService.CreatePlayerService(requestModel);

            return Ok(model);
        }

        
    }
}
