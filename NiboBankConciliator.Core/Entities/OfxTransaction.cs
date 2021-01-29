namespace NiboBankConciliator.Core.Entities
{
    public struct OfxTransaction : IBankTransaction
    {
        public string TransType { get; set; }
        public string TransAmount { get; set; }
        public string DatePosted { get; set; }
        public string Memo { get; set; }
    }

    public enum TransTypes
    {
        Debit, Credit
    }
}
