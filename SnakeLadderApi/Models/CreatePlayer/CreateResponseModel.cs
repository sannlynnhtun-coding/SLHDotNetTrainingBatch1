namespace SnakeLadderApi.Models.CreatePlayer
{
    public class CreateResponseModel : BasedResponseModel
    {
        public int PlayerId { get; set; }

        public string? PlayerName { get; set; }
    }
}
