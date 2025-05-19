namespace SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.Deposit
{
    public class DepositResponseModel : ResponseModel
    {
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
    }
}
