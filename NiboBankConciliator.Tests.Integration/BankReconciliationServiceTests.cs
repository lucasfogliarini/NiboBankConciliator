using NiboBankConciliator.Core.Entities;
using NiboBankConciliator.Core.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NiboBankConciliator.Tests.Integration
{
    public class BankReconciliationServiceTests
    {
        readonly IBankReconciliationService _bankReconciliationService;
        public BankReconciliationServiceTests(IBankReconciliationService bankReconciliationService)
        {
            _bankReconciliationService = bankReconciliationService;
        }

        [Fact]
        public void ReconcileAndSave_Should_ReconcileAndSave()
        {
            //Given
            IEnumerable<OfxDocument> ofxDocuments = new List<OfxDocument>()
            {
                new OfxDocument()
                {
                    BankID = "0341",
                    AccountID = "7037300576",
                    AccountType = "CHECKING",
                    Transactions = new List<OfxTransaction>()
                    {
                        new OfxTransaction()
                        {
                            TransType = TransType.Debit,
                            DatePosted = new DateTime(2021,01,02),
                            TransAmount = -102.19m,
                            Memo = "RSHOP-SUPERMERCAD-03/02"
                        },
                        new OfxTransaction()
                        {
                            TransType = TransType.Credit,
                            DatePosted = new DateTime(2021,01,02),
                            TransAmount = 16766.28m,
                            Memo = "TED 399.1934NIBO SOF CUR"
                        }
                    }
                },
                new OfxDocument()
                {
                    BankID = "0341",
                    AccountID = "7037300576",
                    AccountType = "CHECKING",
                    Transactions = new List<OfxTransaction>()
                    {
                        new OfxTransaction()
                        {
                            TransType = TransType.Credit,
                            DatePosted = new DateTime(2021,01,02),
                            TransAmount = 16766.28m,
                            Memo = "TED 399.1934NIBO SOF CUR"
                        }
                    }
                }
            };


            //When
            var bankAccount = _bankReconciliationService.ReconcileAndAddTransactions(ofxDocuments);

            //Then
            var expectedTransactionsCount = 2;
            Assert.Equal(expectedTransactionsCount, bankAccount.Transactions.Count);
        }
    }
}
