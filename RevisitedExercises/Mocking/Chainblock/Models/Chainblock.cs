using Blockchain.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain.Models
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> _transactions;

        public Chainblock()
        {
            this._transactions = new Dictionary<int, ITransaction>();
        }
        public int Count => this._transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!this._transactions.ContainsKey(tx.Id))
            {
                _transactions[tx.Id] = tx;
            }
            else
            {
                throw new InvalidOperationException($"Transaction with id: {tx.Id} already exists.");
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (this.Contains(id))
            {
                _transactions[id].Status = newStatus;
            }
            else
            {
                throw new ArgumentException($"{id} id does noe exist!");
            }
        }

        public bool Contains(ITransaction tx)
        {
            if (_transactions.ContainsKey(tx.Id))
            {
                ITransaction transaction = _transactions[tx.Id];

                return
                    transaction.Status == tx.Status &&
                    transaction.From == tx.From &&
                    transaction.To == tx.To &&
                    transaction.Amount == tx.Amount;

            }
            else
            {
                return false;
            }
        }

        public bool Contains(int id)
        {
            return _transactions.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return _transactions
                .Values
                .Where(t => t.Amount >= lo && t.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            var transactions = _transactions
                .Values
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            Validator.ValidateNotEmpty(transactions, "The Chainblock is empty");

            return transactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var result = _transactions
                .Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To);

            Validator<string>.ValidateNotEmpty(result, $"Receivers with {status} status do not exist");

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var result = _transactions
               .Values
               .Where(t => t.Status == status)
               .OrderBy(t => t.Amount)
               .Select(t => t.From);

            Validator<string>.ValidateNotEmpty(result, $"Senders with {status} status do not exist");

            return result;
        }

        public ITransaction GetById(int id)
        {
            if (!Contains(id))
            {
                throw new InvalidOperationException($"Transaction with {id} do not exist.");
            }

            return _transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var result = _transactions
                .Values
                .Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo && t.Amount <= hi);

            Validator<ITransaction>.ValidateNotEmpty(result, "There are not such transactions.");

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var result = _transactions
              .Values
              .Where(t => t.To == receiver)
              .OrderBy(t => t.Amount)
              .ThenBy(t => t.Id);

            Validator<ITransaction>.ValidateNotEmpty(result, "There are not such transactions");

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            return _transactions
              .Values
              .Where(t => t.From == sender)
              .Where(t => t.Amount >= amount)
              .OrderByDescending(t => t.Amount);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var result = _transactions
             .Values
             .Where(t => t.From == sender)
             .OrderByDescending(t => t.Amount);

            Validator<ITransaction>.ValidateNotEmpty(result, "There are not such transactions");

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var result = _transactions
            .Values
             .Where(t => t.Status == status);

            Validator<ITransaction>.ValidateNotEmpty(result, $"Transactions with {status} status does not exist.");

            return result;


        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            var result = _transactions
             .Values
             .Where(t => t.Status == status)
             .Where(t => t.Amount <= amount);

            Validator<ITransaction>.ValidateNotEmpty(result, $"Transactions with {status} status does not exist.");

            return result;
        }

        public void RemoveTransactionById(int id)
        {
            if (Contains(id))
            {
                _transactions.Remove(id);
            }
            else
            {
                throw new InvalidOperationException($"Transaction with {id} does not exist.");
            }
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (ITransaction transaction in _transactions.Values)
            {
                yield return transaction;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
