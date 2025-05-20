namespace SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.CheckBalance
{
    public partial class CheckBalanceController
    {
        public class CheckBalanceResponseModel : ResponseModel
        {
            public decimal Balance { get; set; }
            public string MobileNo { get; set; }
            public List<CheckBalanceTransactionHistoryModel> TransactionHistoryList { get; set; }
        }

        public class CheckBalanceTransactionHistoryModel
        {
            public string TransactionNo { get; set; } = null!;

            public string FromMobileNo { get; set; } = null!;

            public string ToMobileNo { get; set; } = null!;

            public decimal Amount { get; set; }

            public DateTime TransactionDate { get; set; }
        }
    }
}
