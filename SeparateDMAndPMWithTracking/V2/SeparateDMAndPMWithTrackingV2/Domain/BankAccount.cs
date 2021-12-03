using System;

namespace SeparateDMAndPMWithTrackingV2.Domain
{
    public class BankAccount : AggregateRoot<IBankAccountState>
    {
        public Status Status { get; }

        public BankAccount(IBankAccountState state)
            : base(state)
        {
            ThrowIfNegativeBalance(state.Balance);
            Status = new Status(state);
        }

        public void Withdraw(decimal amount)
        {
            ThrowIfFrozen("Can not withdraw balance if account is frozen.");

            decimal _amount = Math.Abs(amount);
            ThrowIfNegativeBalance(_state.Balance - _amount);

            _state.Balance -= _amount;
        }

        public void Deposit(decimal amount)
        {
            ThrowIfFrozen("Can not deposit balance if account is frozen.");
            _state.Balance += Math.Abs(amount);
        }


        private void ThrowIfNegativeBalance(decimal balance)
        {
            if (balance < 0)
                throw new Exception(
                    "A bank account with negative balance can not exist");
        }

        private void ThrowIfFrozen(string message)
        {
            if (_state.Frozen)
                throw new Exception(message);
        }
    }
}
