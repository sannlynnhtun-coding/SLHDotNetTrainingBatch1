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

        private readonly UpdatePlayerPositionService _updatePlayerPositionService;

        public PlayerPositionController(UpdatePlayerPositionService updatePlayerPositionService)
        {
            _updatePlayerPositionService = updatePlayerPositionService;
        }

        [HttpPost("Update")]

        public IActionResult UpdatePlayerPosition([FromBody] UpdatePlayerPositionRequestModel requestModel)
        {

            //use _updatePlayerPositionService to update the player position

            
            var response = _updatePlayerPositionService.UpdatePlayerPosition(requestModel);

            return Ok(response);
        }
    }
}
