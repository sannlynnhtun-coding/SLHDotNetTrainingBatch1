namespace SLHDotNetTrainingBatch1.WebApi.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
