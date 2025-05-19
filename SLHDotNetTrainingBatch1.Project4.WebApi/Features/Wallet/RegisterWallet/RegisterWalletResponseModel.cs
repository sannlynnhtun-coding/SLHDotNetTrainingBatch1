namespace SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.RegisterWallet
{
    public class RegisterWalletResponseModel : ResponseModel
    {
        public int WalletId { get; set; }
        public string WalletUserName { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
    }
}
