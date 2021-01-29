using System.Collections.Generic;

namespace NiboBankConciliator.Core.Entities
{
    public interface IBankDocument
    {
        public List<IBankTransaction> Transactions { get; set; }
        public string AccountType { get; set; }
        public string AccountID { get; set; }
        public string BankID { get; set; }
    }
}
