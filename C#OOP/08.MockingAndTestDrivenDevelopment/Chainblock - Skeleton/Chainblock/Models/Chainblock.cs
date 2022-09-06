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
            return transactionById
                .Values
                .Where(t => t.Amount >= lo
                        && t.Amount <= hi);

        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            var transactions = transactionById
                .Values
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("The Chainblock is empty");
            }

            return transactions;
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
            var transactions = transactionById
                .Values
                .Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo
                         && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("There are not such transactions");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var transactions = transactionById
                .Values
                .Where(t => t.To == receiver)
                .OrderBy(t => t.Amount)
                .ThenBy(t => t.Id);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("There are not such transactions");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var transactions = transactionById
                .Values
                .Where(t => t.From == sender)
                .Where(t => t.Amount > amount)
                .OrderByDescending(t => t.Amount);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("There are not such transactions");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var transactions = transactionById
                .Values
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("There are not such transactions");
            }

            return transactions;
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
            var result = transactionById
               .Values
               .Where(t => t.Status == status)
               .Where(t => t.Amount <= 100)
               .OrderByDescending(t => t.Amount);

            return result;
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
