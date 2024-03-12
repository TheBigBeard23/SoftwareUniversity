using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Models
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

                if (transaction.Status == tx.Status &&
                    transaction.From == tx.From &&
                    transaction.To == tx.To &&
                    transaction.Amount == tx.Amount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            return _transactions
                .Values
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var result = _transactions
                .Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException($"Receivers with {status} do not exist");
            }

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
