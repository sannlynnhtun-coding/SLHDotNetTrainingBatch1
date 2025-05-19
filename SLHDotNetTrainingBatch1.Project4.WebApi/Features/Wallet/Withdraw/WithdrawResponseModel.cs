namespace SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.Withdraw
{
    public class WithdrawResponseModel : ResponseModel
    {
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
    }
}
