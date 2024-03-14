using Blockchain.Contracts;
using Blockchain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction transaction;

        private int id;
        private TransactionStatus status;
        private string from;
        private string to;
        private double amount;

        [SetUp]
        public void SetUp()
        {
            chainblock = new Chainblock();

            id = 101;
            status = TransactionStatus.Successfull;
            from = "Ivan";
            to = "Pesho";
            amount = 10000;
            transaction = new Transaction(id, status, from, to, amount);

            chainblock.Add(transaction);
        }

        [Test]
        public void GetByTransactionStatus_ReturnsTransactionsWithMatchingStatus()
        {
            IEnumerable<ITransaction> transactions = chainblock.GetByTransactionStatus(status);

            Assert.AreEqual(transactions.Count(), 1);
            Assert.AreEqual(transactions.First(), transaction);
        }
        [Test]
        public void GetByTransactionStatus_ThrowsExceptionForEmptyTransactions()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<ITransaction> transactions = chainblock.GetByTransactionStatus(TransactionStatus.Failed);
            });


            Assert.AreEqual($"Transactions with {TransactionStatus.Failed} status does not exist.", ex.Message);


        }
    }
}
