using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnakeLadderApi.Models.PlayerPosition;
using SnakeLadderApi.Services.PlayerPositionServices;

namespace SnakeLadderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerPositionController : ControllerBase
    {

        private readonly CreatePlayerPositionService _updatePlayerPositionService;

        public PlayerPositionController(CreatePlayerPositionService updatePlayerPositionService)
        {
            _updatePlayerPositionService = updatePlayerPositionService;
        }

        [HttpPost]
        [Route("CreatePlayerPosition")]
        public IActionResult CreatePlayerPosition(UpdatePlayerPositionRequestModel requestModel)
        {
            var model = _updatePlayerPositionService.CreatePlayerPosition(requestModel);

            return Ok(model);
        }
    }
}
