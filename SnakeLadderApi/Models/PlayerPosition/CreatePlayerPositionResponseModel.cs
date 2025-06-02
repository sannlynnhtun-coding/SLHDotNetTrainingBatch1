namespace SnakeLadderApi.Models.PlayerPosition
{
    public class CreatePlayerPositionResponseModel:BasedResponseModel
    {
        public int PlayerId { get; set; }
        public int CurrentPosition { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
