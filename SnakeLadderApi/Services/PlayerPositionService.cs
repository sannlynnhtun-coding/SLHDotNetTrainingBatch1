using SLHDotNetTrainingBatch1.Shared;
using SnakeLadderApi.Models;

namespace SnakeLadderApi.Services;

public class PlayerPositionService
{
    private readonly IDbV2Service _dapperService;

    public PlayerPositionService(IDbV2Service dapperService)
    {
        _dapperService = dapperService;
    }

    //public ResponseModel CreatePlayerLocation(PlayerLocationModel requestModel)
    //{
    //    /*
    //     Select previous RowNo by PlayerId

    //     */
    //    string selectQuery =

    //    string query = @" insert into Tbl_PlayerLocation(
    //                    PlayerId
    //                    PlayerRowNo
    //                    )
    //                    values(
    //                    @PlayerId,
    //                    @PlayerRowNo
    //                    )";
    //    int result = _dapperService.Execute(query, requestModel);
    //    var model = new ResponseModel
    //    {
    //        IsSuccess = result > 0,
    //        Message = result > 0 ? "Success." : "Fail.",
    //    };
    //    return model;

    //}

}
