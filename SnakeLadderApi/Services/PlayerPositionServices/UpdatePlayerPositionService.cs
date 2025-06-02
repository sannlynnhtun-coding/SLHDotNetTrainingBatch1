using SnakeLadder.Database.Entities;
using SnakeLadderApi.Models;
using SnakeLadderApi.Models.PlayerPosition;

namespace SnakeLadderApi.Services.PlayerPositionServices;

public class UpdatePlayerPositionService
{

    private readonly AppDbContext _context;

    public UpdatePlayerPositionService(AppDbContext context)
    {
        _context = context;
    }


    public UpdatePlayerPositionResponseModel UpdatePlayerPosition(UpdatePlayerPositionRequestModel requestModel)
    {
        // Implement Logic here then return the response model


        return new UpdatePlayerPositionResponseModel
        {
            PlayerId = requestModel.PlayerPositionId
        };
    }
}
