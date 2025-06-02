namespace SnakeLadderApi.Models.PlayerPosition
{
    public class CreatePlayerPositionResponseModel
    {
        public int PlayerId { get; set; }
        public int CurrentPosition { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
