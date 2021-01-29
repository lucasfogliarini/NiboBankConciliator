namespace NiboBankConciliator.Core.Entities
{
    public interface IBankTransaction
    {
        public string TransType { get; set; }
        public string TransAmount { get; set; }
        public string DatePosted { get; set; }
        public string Memo { get; set; }
    }
}
