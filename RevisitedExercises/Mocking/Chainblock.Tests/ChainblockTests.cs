using Blockchain.Contracts;
using Blockchain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public void Count_ReturnsExpectedCount()
        {
            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]
        public void Add_ValidTransaction_NoExistingId_AddsToTransactionDictionary()
        {
            int count = chainblock.Count;

            transaction = new Transaction(102, status, from, to, amount);
            chainblock.Add(transaction);

            Assert.AreEqual(count + 1, chainblock.Count);
            Assert.IsTrue(chainblock.Contains(transaction));
        }

        [Test]
        public void Add_TransactionWithExistingId_ThrowsInvalidOperationException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.Add(transaction);
            });

            Assert.AreEqual($"Transaction with id: {transaction.Id} already exists.", ex.Message);
        }

        [Test]
        public void ChangeTransactionStatus_ExistingId_ValidStatus_UpdatesStatus()
        {
            TransactionStatus newStatus = TransactionStatus.Failed;

            chainblock.ChangeTransactionStatus(id, newStatus);

            var transaction = chainblock.GetById(id);

            Assert.AreEqual(newStatus, transaction.Status);

        }

        [Test]
        public void ChangeTransactionStatus_NonExistingId_ThrowsArgumentException()
        {
            id = 102;
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                chainblock.ChangeTransactionStatus(id, status);
            });

            Assert.AreEqual($"{id} id does noe exist!", ex.Message);
        }

        [Test]
        public void ContainsByTransaction_ExistingTransaction_ReturnsTrue()
        {
            Assert.IsTrue(chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsByTransaction_NonExistingTransaction_ReturnsFalse()
        {
            transaction = new Transaction(id + 1, status, from, to, amount);

            Assert.IsFalse(chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsById_ExistingTransaction_ReturnsTrue()
        {
            Assert.IsTrue(chainblock.Contains(id));
        }

        [Test]
        public void ContainsById_NonExistingTransaction_ReturnsFalse()
        {
            Assert.IsFalse(chainblock.Contains(id + 1));
        }

        [Test]
        public void GetAllInAmountRange_TransactionsInRange_ReturnsCorrectTransactions()
        {
            int lo = 9997;
            int hi = 10000;

            for (int i = lo; i < hi; i++)
            {
                chainblock.Add(new Transaction(i, status, from, to, i));
            }

            var result = chainblock.GetAllInAmountRange(lo, hi);

            foreach (var transaction in result)
            {
                Assert.IsTrue(transaction.Amount >= lo && transaction.Amount <= hi);
            }
        }

        [Test]
        public void GetAllInAmountRange_NoTransactionsInRange_ThrowsInvalidOperationException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetAllInAmountRange(amount + 1, amount + 2);
            });

            Assert.AreEqual("The Chainblock is empty", ex.Message);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ReturnsOrderedTransactions()
        {
            for (int i = 1; i < 6; i++)
            {
                chainblock.Add(new Transaction(id + i, status, from, to, amount + i));
            }

            var result = chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            for (int t = 1; t < result.Count(); t++)
            {
                Assert.IsTrue(result[t - 1].Amount >= result[t].Amount);
                Assert.IsTrue(result[t - 1].Id >= result[t].Id);
            }
        }

        //[Test]
        //public void GetByTransactionStatus_ReturnsTransactionsWithMatchingStatus()
        //{
        //    IEnumerable<ITransaction> transactions = chainblock.GetByTransactionStatus(status);

        //    Assert.AreEqual(transactions.Count(), 1);
        //    Assert.AreEqual(transactions.First(), transaction);
        //}
        //[Test]
        //public void GetByTransactionStatus_ThrowsExceptionForEmptyTransactions()
        //{
        //    InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
        //    {
        //        IEnumerable<ITransaction> transactions = chainblock.GetByTransactionStatus(TransactionStatus.Failed);
        //    });


        //    Assert.AreEqual($"Transactions with {TransactionStatus.Failed} status does not exist.", ex.Message);


        //}
    }
}
