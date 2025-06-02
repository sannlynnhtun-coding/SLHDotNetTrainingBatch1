using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SLHDotNetTrainingBatch1.Shared;
using SnakeLadder.Database.Entities;
using SnakeLadderApi.Models;
using SnakeLadderApi.Models.CreatePlayer;

namespace SnakeLadderApi.Services.CreatePlayerService
{
    public class CreatePlyerService
    {

        private readonly AppDbContext _context;

        public CreatePlyerService(AppDbContext context)
        {
            _context = context;
        }

        CreateResponseModel model;
        public BasedResponseModel CreatePlayerService(CreateRequestModel requestModel)
        {
            if(requestModel.PlayerName.IsNullOrEmptyV2())
            {
                return new BasedResponseModel
                {
                    Message = "Player name is requreid !"
                };
            }


             var item = _context.TblPlayers.Add(new TblPlayer
            {
                PlayerName = requestModel.PlayerName,
            });
           
            if(item is null)
            {
                  var model = new BasedResponseModel
                {
                    Message = "fail to create",
                };
            }
            model = new CreateResponseModel
            {
                IsSuccess = true,
                Message = "Success To Create",
                PlayerName = requestModel.PlayerName,
            };
            return model;



        }
    }
}
