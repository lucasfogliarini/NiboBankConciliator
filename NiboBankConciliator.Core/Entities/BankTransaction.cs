using System;
using System.ComponentModel;

namespace NiboBankConciliator.Core.Entities
{
    public class BankTransaction
    {
        [DisplayName("Type")]
        public TransType TransType { get; set; }
        [DisplayName("Amount")]
        public decimal TransAmount { get; set; }
        [DisplayName("Date")]
        public DateTime DatePosted { get; set; }
        [DisplayName("Memo")]
        public string Memo { get; set; }
    }
}
