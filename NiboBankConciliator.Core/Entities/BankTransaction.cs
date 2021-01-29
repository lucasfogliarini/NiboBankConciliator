using System;

namespace NiboBankConciliator.Core.Entities
{
    public class BankTransaction
    {
        public TransType TransType { get; set; }
        public decimal TransAmount { get; set; }
        public DateTime DatePosted { get; set; }
        public string Memo { get; set; }
    }
}
