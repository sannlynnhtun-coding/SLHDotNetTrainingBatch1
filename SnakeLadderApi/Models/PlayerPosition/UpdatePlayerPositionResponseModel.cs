namespace SnakeLadderApi.Models.PlayerPosition
{
    public class UpdatePlayerPositionResponseModel:BasedResponseModel
    {

        public int PlayerId { get; set; }

        public string PlayerName { get; set; }

        public int PreviousPosition { get; set; }

        public int CurrentPosition { get; set; }

    }
}
