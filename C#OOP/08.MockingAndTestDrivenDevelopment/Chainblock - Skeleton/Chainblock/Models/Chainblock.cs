using Blockchain.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            var result = transactionById
               .Values
               .Where(t => t.Status == status)
               .OrderBy(t => t.Amount)
               .Select(t => t.To);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException($"Receivers with {status} status do not exist");
            }

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var result = transactionById
                .Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException($"Senders with {status} status do not exist");
            }

            return result;
        }

        public ITransaction GetById(int id)
        {
            if (!Contains(id))
            {
                throw new InvalidOperationException($"Transactios with {id} do not exist.");
            }
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
            var result = transactionById
                .Values
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException($"Transactions with {status} does not exist.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }
        public void RemoveTransactionById(int id)
        {
            if (Contains(id))
            {
                transactionById.Remove(id);
            }
            else
            {
                throw new InvalidOperationException($"Transaction with {id} does not exist.");
            }
        }
        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in transactionById)
            {
                yield return transaction.Value;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
