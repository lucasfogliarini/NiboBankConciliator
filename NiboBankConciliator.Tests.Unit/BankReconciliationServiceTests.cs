using System;
using Xunit;
using NiboBankConciliator.Core.Services;
using NiboBankConciliator.Core.Entities;
using System.Collections.Generic;

namespace NiboBankConciliator.Tests.Unit
{
    public class BankReconciliationServiceTests
    {
        readonly IBankReconciliationService _bankReconciliationService;

        public BankReconciliationServiceTests()
        {
            _bankReconciliationService = new BankReconciliationService();
        }

        [Fact]
        public void Reconcile_Should_Reconciliate()
        {
            //Given
            IBankDocument bankDocument = new OfxDocument()
            {
                BankID = "0341",
                AccountID = "7037300576",
                AccountType = "CHECKING",
                Transactions = new List<OfxTransaction>()
                {
                    new OfxTransaction()
                    {
                        TransType = "DEBIT",
                        DatePosted = "20140204100000[-03:EST]",
                        TransAmount = "-102.19",
                        Memo = "RSHOP-SUPERMERCAD-03/02"
                    }
                }
            };


            //When
            _bankReconciliationService.Reconcile(bankDocument);

            //Then
        }
    }
}
