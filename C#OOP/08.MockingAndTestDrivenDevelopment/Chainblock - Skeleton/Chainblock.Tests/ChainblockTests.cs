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

            id = 1;
            status = TransactionStatus.Successfull;
            from = "Vlad";
            to = "Jon";
            amount = 100;
            transaction = new Transaction(id, status, from, to, amount);

            chainblock.Add(transaction);
        }

        [Test]
        public void Add_ShouldAddsTransactionToChainblock_WhenTransactionIdDoesNotExists()
        {
            Assert.That(chainblock.Count, Is.EqualTo(1));
            Assert.That(chainblock.Contains(transaction));
        }

        [Test]
        public void Add_ShouldThrowException_WhenTransactionWithIdAlreadyExists()
        {
            status = TransactionStatus.Failed;
            from = "Ivan";
            to = "Jon";
            amount = 100;
            transaction = new Transaction(id, status, from, to, amount);

            Assert.Throws<InvalidOperationException>(() => chainblock.Add(transaction));
        }

        [Test]
        public void ContainsId_ShouldReturnTrue_WhenTransactionWithIdExist()
        {
            Assert.AreEqual(true, chainblock.Contains(id));
        }

        [Test]
        public void ContainsId_ShouldReturnFalse_WhenTransactionWithIdDoesNotExist()
        {
            Assert.AreEqual(false, chainblock.Contains((id + 3 * 4) / 2));
        }

        [Test]
        public void ContainsTransaction_ShouldReturnFalse_WhenTransactionWithIdDoesNotExist()
        {
            transaction = new Transaction(9, status, from, to, amount);
            Assert.AreEqual(false, chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsTransaction_ShouldReturnFalse_WhenTransactionIdExist_ButOtherPropertiesDoNotMatch()
        {
            status = TransactionStatus.Aborted;
            from = "Pesho";
            to = "Jose";
            amount = 1000;
            transaction = new Transaction(id, status, from, to, amount);
            Assert.AreEqual(false, chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsTransaction_ShouldReturnTrue_WhenTransactionExist()
        {
            Assert.AreEqual(true, chainblock.Contains(transaction));
        }

        [Test]
        public void Count_ShouldReturnZero_WhenChainblockIsEmpty()
        {
            Assert.That(chainblock.Count, Is.EqualTo(1));
        }

        [Test]
        public void ChangeTransactionStatus_ThrowsException_WhenIdDoesNotExist()
        {
            Assert.Throws<ArgumentException>(()
                => chainblock.ChangeTransactionStatus(id + 1, TransactionStatus.Aborted));
        }

        [Test]
        public void ChangeTransactionStatus_ShouldChangesTransactionStatus_WhenIdExist()
        {
            status = TransactionStatus.Aborted;
            chainblock.ChangeTransactionStatus(id, status);
            transaction = chainblock.GetById(id);
            Assert.That(status, Is.EqualTo(transaction.Status));
        }

        [Test]
        public void RemoveById_ShouldThrowException_WhenIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(()
                => chainblock.RemoveTransactionById(id + 1));
        }

        [Test]
        public void RemoveById_ShouldRemoveTransaction_WhenIdExist()
        {
            var count = chainblock.Count - 1;
            chainblock.RemoveTransactionById(id);
            Assert.AreEqual(count, chainblock.Count);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(id));
        }

        [Test]
        public void GetById_ShouldThrowException_WhenIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(id + 1));
        }

        [Test]
        public void GetById_ShouldReturnTransaction_WhenIdExist()
        {
            Assert.AreEqual(transaction, chainblock.GetById(id));
        }

        [Test]
        public void GetByTransactionStatus_ShouldThrowException_WhenStatusDoesNotExist()
        {
            var status = TransactionStatus.Failed;
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(status));
        }

        [Test]
        public void GetByTransactionStatus_ShouldReturnTransactions_WhenTransactionStatusMatch()
        {
            transaction = new Transaction(2, status, "Ivan", "Pesho", 5);
            chainblock.Add(transaction);
            transaction = new Transaction(3, status, "Jon", "Pesho", 10);
            chainblock.Add(transaction);
            List<ITransaction> transactions = (List<ITransaction>)chainblock.GetByTransactionStatus(status);
            Assert.AreEqual(3, transactions.Count);

            var prevAmount = transactions.FirstOrDefault().Amount;

            foreach (var transaction in transactions)
            {
                Assert.AreEqual(status, transaction.Status);
                Assert.That(transaction.Amount <= prevAmount);
                prevAmount = transaction.Amount;
            }
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldThrowException_WhenStatusDoesNotExist()
        {
            var status = TransactionStatus.Failed;
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(status));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldReturnAllSenders_WhenTransactionStatusMatch()
        {

            transaction = new Transaction(2, status, "Ivan", "Pesho", 50);
            chainblock.Add(transaction);
            transaction = new Transaction(3, status, "Jon", "Pesho", 1000);
            chainblock.Add(transaction);

            var expectedSenders = chainblock
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From);

            var senders = chainblock.GetAllSendersWithTransactionStatus(status);

            Assert.That(expectedSenders, Is.EquivalentTo(senders));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldThrowException_WhenStatusDoesNotExist()
        {
            var status = TransactionStatus.Failed;
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(status));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldReturnAllReceivers_WhenTransactionStatusMatch()
        {
            transaction = new Transaction(2, status, "Ivan", "Pesho", 100);
            chainblock.Add(transaction);
            transaction = new Transaction(3, status, "Jon", "Pesho", 1000);
            chainblock.Add(transaction);

            var expectedReceivers = chainblock
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To);

            var receivers = chainblock.GetAllReceiversWithTransactionStatus(status);

            Assert.That(expectedReceivers, Is.EquivalentTo(receivers));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldThrowException_WhenChainblockIsEmpty()
        {
            chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldReturnTransactionOrderedByAmountThenById()
        {
            transaction = new Transaction(2, status, "Ivan", "Pesho", 100);
            chainblock.Add(transaction);
            transaction = new Transaction(3, status, "Jon", "Pesho", 1000);
            chainblock.Add(transaction);

            var expectedTransactions = chainblock
                .OrderBy(t => t.Amount)
                .ThenBy(t => t.Id);

            var transactions = chainblock.GetAllOrderedByAmountDescendingThenById();

            Assert.That(expectedTransactions, Is.EquivalentTo(transactions));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldThrowException_WhenTransactionsWithSenderDoNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("Test"));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldReturnTransactionsFilteredBySenderAndOrderedDescendingByAmount()
        {
            transaction = new Transaction(5, status, from, "Pepi", 10);
            chainblock.Add(transaction);
            transaction = new Transaction(8, status, from, "Gogi", 15);
            chainblock.Add(transaction);
            transaction = new Transaction(9, status, from, "Sashi", 19);
            chainblock.Add(transaction);

            var expectedTransactions = chainblock
                .Where(t => t.From == from)
                .OrderByDescending(t => t.Amount);

            var transactions = chainblock.GetBySenderOrderedByAmountDescending(from);

            Assert.That(expectedTransactions, Is.EquivalentTo(transactions));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldThrowException_WhenTransactionsWithReceiverDoNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("Test"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldReturnTransactionsFilteredByReceiverOrderedByAmountThenById()
        {
            transaction = new Transaction(5, status, "Pepi", to, 10);
            chainblock.Add(transaction);
            transaction = new Transaction(8, status, "Gogi", to, 15);
            chainblock.Add(transaction);
            transaction = new Transaction(9, status, "Sashi", to, 19);
            chainblock.Add(transaction);

            var expectedTransactions = chainblock
                .Where(t => t.To == to)
                .OrderBy(t => t.Amount)
                .ThenBy(t => t.Id);

            var transactions = chainblock.GetByReceiverOrderedByAmountThenById(to);

            Assert.That(expectedTransactions, Is.EquivalentTo(transactions));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnEmptyCollection_WhenTransactionsDoNotMatch()
        {
            var transactions = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 10);
            Assert.That(transactions, Is.Empty);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnFilteredTransactionsByStatusThenByAmountAndOrderedByAmountDescending()
        {
            transaction = new Transaction(5, status, "Pepi", to, 10);
            chainblock.Add(transaction);
            transaction = new Transaction(8, status, "Gogi", to, 15);
            chainblock.Add(transaction);
            transaction = new Transaction(9, status, "Sashi", to, 19);
            chainblock.Add(transaction);

            var expectedTransactions = chainblock
                .Where(t => t.Status == status)
                .Where(t => t.Amount <= 100)
                .OrderByDescending(t => t.Amount);

            var transactions = chainblock.GetByTransactionStatusAndMaximumAmount(status, 100);

            Assert.That(expectedTransactions, Is.EquivalentTo(transactions));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowException_WhenTransactionsDoNotMatch()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending(from, 10000));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldReturnFilteredTransactionsBySenderAndOrderedByAmountDescending()
        {
            transaction = new Transaction(5, status, from, "Pepi", 10);
            chainblock.Add(transaction);
            transaction = new Transaction(8, status, from, "Gogi", 15);
            chainblock.Add(transaction);
            transaction = new Transaction(9, status, from, "Sashi", 19);
            chainblock.Add(transaction);

            var expectedTransactions = chainblock
                .Where(t => t.From == from)
                .Where(t => t.Amount > 5)
                .OrderByDescending(t => t.Amount);

            var transactions = chainblock.GetBySenderAndMinimumAmountDescending(from, 5);

            Assert.That(expectedTransactions, Is.EquivalentTo(transactions));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrowException_WhenTransactionsDoNotMatch()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Test", 10, 20));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldReturnFilteredTransactionsByReceiverAndOrderedByAmountDescendingThenById()
        {
            transaction = new Transaction(5, status, "Pepi", to, 10);
            chainblock.Add(transaction);
            transaction = new Transaction(8, status, "Gogi", to, 15);
            chainblock.Add(transaction);
            transaction = new Transaction(9, status, "Sashi", to, 19);
            chainblock.Add(transaction);

            double lo = 1;
            double hi = 100;

            var expectedTransactions = chainblock
                .Where(t => t.To == to)
                .Where(t => t.Amount >= lo
                         && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            var transactions = chainblock.GetByReceiverAndAmountRange(to, lo, hi);

            Assert.That(expectedTransactions, Is.EquivalentTo(transactions));
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnEmptyCollection_WhenTransactionsDoNotMatch()
        {
            var transactions = chainblock.GetAllInAmountRange(1, 5);
            Assert.That(transactions, Is.Empty);
        }


        [Test]
        public void GetAllInAmountRange_ShouldReturnTransactionsFilteredByAmountInRange()
        {
            transaction = new Transaction(5, status, "Pepi", to, 10);
            chainblock.Add(transaction);
            transaction = new Transaction(8, status, "Gogi", to, 15);
            chainblock.Add(transaction);
            transaction = new Transaction(9, status, "Sashi", to, 19);
            chainblock.Add(transaction);

            double lo = 1;
            double hi = 100;

            var expectedTransactions = chainblock
               .Where(t => t.Amount >= lo
                        && t.Amount <= hi);

            var transactions = chainblock.GetAllInAmountRange(lo, hi);

            Assert.That(expectedTransactions, Is.EquivalentTo(transactions));
        }
    }
}

