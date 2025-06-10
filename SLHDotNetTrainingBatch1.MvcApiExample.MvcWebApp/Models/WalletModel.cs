namespace SLHDotNetTrainingBatch1.MvcApiExample.MvcWebApp.Models
{
    public class WalletModel
    {
        public int WalletId { get; set; }

        public string WalletUserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string MobileNo { get; set; } = null!;

        public decimal Balance { get; set; }
    }
}
