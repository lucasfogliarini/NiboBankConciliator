using System.Collections.Generic;
using System.ComponentModel;

namespace NiboBankConciliator.Core.Entities
{
    public class BankAccount
    {
        [DisplayName("Bank Id")]
        public string BankID { get; set; }
        [DisplayName("Account Id")]
        public string AccountID { get; set; }
        [DisplayName("Type")]
        public string AccountType { get; set; }
        public List<BankTransaction> Transactions { get; set; }
    }
}
