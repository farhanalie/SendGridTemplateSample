namespace SendGridTemplateSample.Models
{
    public class Sample3Model : EmailModel
    {
        public string ReceiverName { get; set; }
        public string DestinationNumber { get; set; }
        public string DestinationCountry { get; set; }
        public string CreditedAmount { get; set; }
        public string CreditedCurrency { get; set; }
        public string TransactionId { get; set; }
        public string SenderName { get; set; }
        public string ErrorCode { get; set; }
        public string SendingAmount { get; set; }
        public string ExchangeRate { get; set; }
        public string FeeCharged { get; set; }
        public string ChargedAmount { get; set; }

    }
}