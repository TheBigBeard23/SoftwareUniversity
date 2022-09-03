using Blockchain.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Blockchain.Models
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactionById;
        public Chainblock()
        {
            transactionById = new Dictionary<int, ITransaction>();
        }
        public int Count => transactionById.Count;

        public void Add(ITransaction tx)
        {
            if (transactionById.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException($"Transaction with id: {tx.Id} already exists.");
            }

            transactionById.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (this.Contains(id))
            {
                transactionById[id].Status = newStatus;
            }
            else
            {
                throw new ArgumentException($"{id} id does not exist.");
            }
        }

        public bool Contains(ITransaction tx)
        {
            if (this.Contains(tx.Id))
            {
                ITransaction transaction = transactionById[tx.Id];

                return tx.From == transaction.From &&
                       tx.To == transaction.To &&
                       tx.Status == transaction.Status &&
                       tx.Amount == transaction.Amount;
            }

            return false;
        }

        public bool Contains(int id)
        {
            return transactionById.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            return transactionById[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
