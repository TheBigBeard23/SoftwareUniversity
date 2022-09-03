using Blockchain.Contracts;
using Blockchain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
            transaction = new Transaction(2, status, "Ivan", "Pesho", 100);
            chainblock.Add(transaction);
            List<ITransaction> transactions = (List<ITransaction>)chainblock.GetByTransactionStatus(status);
            Assert.AreEqual(2, transactions.Count);

            foreach (var transaction in transactions)
            {
                Assert.AreEqual(status, transaction.Status);
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
            transaction = new Transaction(2, status, "Ivan", "Pesho", 100);
            chainblock.Add(transaction);
            List<string> senders = (List<string>)chainblock.GetAllSendersWithTransactionStatus(status);
            Assert.AreEqual(2, senders.Count);
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
            List<string> receivers = (List<string>)chainblock.GetAllReceiversWithTransactionStatus(status);
            Assert.AreEqual(2, receivers.Count);
        }
    }
}

