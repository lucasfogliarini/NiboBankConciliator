using System.Collections.Generic;

namespace NiboBankConciliator.Core.Entities
{
    public class BankAccount
    {
        public string AccountType { get; set; }
        public string AccountID { get; set; }
        public string BankID { get; set; }
        public List<BankTransaction> Transactions { get; set; }
    }
}
