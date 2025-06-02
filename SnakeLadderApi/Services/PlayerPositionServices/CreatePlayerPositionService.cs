using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SnakeLadder.Database.Entities;
using SnakeLadderApi.Models;
using SnakeLadderApi.Models.PlayerPosition;
using System.Diagnostics.Eventing.Reader;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SnakeLadderApi.Services.PlayerPositionServices;

public class CreatePlayerPositionService
{

    private readonly AppDbContext _context;

    public CreatePlayerPositionService(AppDbContext context)
    {
        _context = context;
    }

    public class DiceRoller
    {
        private static Random random = new Random();

        public static int RollDie()
        {
            return random.Next(1, 7); // 7 is exclusive, so this returns 1 to 6
        }
    }

    public BasedResponseModel CreatePlayerPosition(UpdatePlayerPositionRequestModel requestModel)
    {
        /*
         - Select previous RowNo by PlayerId
         - Take a number ramdonly within 1 to 6
         - Sum ramdon number and previous RowNo 
         - Check current updatedRowNo is same or not with Helper's start number and calculate with it
         - Insert record
         */

        //CreatePlayerPositionResponseModel model;
        int randomNo = DiceRoller.RollDie();
        var currentPositionNo = 0;
        int updatedPositionNo = currentPositionNo + randomNo;

        var item = _context.TblPlayerPositions.Where(x => x.PlayerId == requestModel.PlayerId)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(1)
                    .SingleOrDefault()!;
        if (item is not null)
        {
             currentPositionNo = item.CurrentPosition;
        }
        updatedPositionNo = currentPositionNo + randomNo;

        var itemSnake = _context.TblSnakes.FirstOrDefault(x => x.FromPosition == updatedPositionNo)!;
        
        var itemLadder = _context.TblLadders.FirstOrDefault(x => x.FromPosition == updatedPositionNo)!;

        if (itemSnake is not null)
        {
            updatedPositionNo = itemSnake.ToPosition;
        }

        else if (itemLadder is not null)
        {
            updatedPositionNo = itemLadder.ToPosition;
        }

        _context.TblPlayerPositions.Add(new TblPlayerPosition
        {
            PlayerId = requestModel.PlayerId,
            CurrentPosition = updatedPositionNo,
            CreatedDate = DateTime.UtcNow,
        });
        var affectedRows = _context.SaveChanges();

        var result = new CreatePlayerPositionResponseModel
        {
            PlayerId = requestModel.PlayerId,
            CurrentPosition = updatedPositionNo,
            CreatedDate = DateTime.UtcNow,
        };
        var model = new BasedResponseModel
        {
            IsSuccess = affectedRows > 0,
            Message = affectedRows > 0 ? "Success." : "Fail.",
            Data = result
        };
        return model;
    }
}

