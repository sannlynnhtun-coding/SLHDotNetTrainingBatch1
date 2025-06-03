namespace SnakeLadderApi.Models.PlayerPosition
{
    public class CreatePlayerPositionResponseModel
    {
        public int PlayerId { get; set; }
        public int PreviousPosition { get; set; }
        public int DiceNumber { get; set; }
        public int CurrentPosition { get; set; }

        public string Message { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
