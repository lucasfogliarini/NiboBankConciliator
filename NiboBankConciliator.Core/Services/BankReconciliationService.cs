using NiboBankConciliator.Core.Entities;
using System.Linq;
using System.Collections.Generic;

namespace NiboBankConciliator.Core.Services
{
    public class BankReconciliationService : IBankReconciliationService
    {
        readonly IBankConciliatorRepository _bankConciliatorRepository;
        public BankReconciliationService(IBankConciliatorRepository bankConciliatorRepository)
        {
            _bankConciliatorRepository = bankConciliatorRepository;
        }
        public BankAccount Reconcile(IEnumerable<OfxDocument> ofxDocuments)
        {
            var bankTransactions = new List<BankTransaction>();

            foreach (var ofxDocument in ofxDocuments)
            {
                foreach (var ofxTransactions in ofxDocument.Transactions)
                {
                    bool exists = bankTransactions.Any(t => t.TransAmount == ofxTransactions.TransAmount && 
                                                            t.DatePosted == ofxTransactions.DatePosted && 
                                                            t.Memo == ofxTransactions.Memo && 
                                                            t.TransType == ofxTransactions.TransType);
                    if (!exists)
                    {
                        bankTransactions.Add(new BankTransaction()
                        {
                            TransAmount = ofxTransactions.TransAmount,
                            DatePosted = ofxTransactions.DatePosted,
                            Memo = ofxTransactions.Memo,
                            TransType = ofxTransactions.TransType
                        });
                    }
                }
            }

            var bankDoc = ofxDocuments.FirstOrDefault();
            var bankAccount = new BankAccount()
            {
                Transactions = bankTransactions,
                AccountID = bankDoc.AccountID,
                AccountType = bankDoc.AccountType,
                BankID = bankDoc.BankID
            };
            return bankAccount;
        }

        public BankAccount ReconcileAndAddTransactions(IEnumerable<OfxDocument> ofxDocuments)
        {
            var bankAccount = Reconcile(ofxDocuments);
            _bankConciliatorRepository.Add(bankAccount);
            _bankConciliatorRepository.Commit();
            return bankAccount;
        }
    }
}
