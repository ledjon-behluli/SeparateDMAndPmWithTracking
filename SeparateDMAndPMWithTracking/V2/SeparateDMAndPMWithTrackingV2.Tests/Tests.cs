using System;
using Xunit;
using SeparateDMAndPMWithTrackingV2.Domain;
using SeparateDMAndPMWithTrackingV2.Infrastructure;

namespace SeparateDMAndPMWithTrackingV2.Tests
{
    public class Tests
    {
        readonly IBankAccountState bankAccountEntity;
        readonly BankAccount bankAccount;

        public Tests()
        {
            bankAccountEntity = new BankAccountEntity()
            {
                Id = Guid.NewGuid(),
                Name = "John Smith",
                Balance = 1000m,
                Frozen = false
            };

            bankAccount = new BankAccount(bankAccountEntity);
        }

        [Fact]
        public void FrozenWithNoReasonShouldThrow()
        {
            var _entity = new BankAccountEntity()
            {
                Id = Guid.NewGuid(),
                Name = "John Smith",
                Balance = 1000m,
                Frozen = true,
                Reason = string.Empty
            };

            Assert.Throws<Exception>(() => new BankAccount(_entity));
        }

        [Fact]
        public void NegativeBalanceShouldThrow()
        {
            var _entity = new BankAccountEntity()
            {
                Id = Guid.NewGuid(),
                Name = "John Smith",
                Balance = -100m,
                Frozen = false
            };

            Assert.Throws<Exception>(() => new BankAccount(_entity));
        }

        [Fact]
        public void StateTests()
        {
            var state = bankAccount.GetState();

            Assert.Equal(bankAccountEntity.Id, state.Id);
            Assert.Equal(bankAccountEntity.Name, state.Name);
            Assert.Equal(bankAccountEntity.Balance, state.Balance);
            Assert.Equal(bankAccountEntity.Frozen, state.Frozen);
            Assert.Equal(bankAccountEntity.Reason, state.Reason);


            bankAccount.Deposit(100m);
            Assert.NotEqual(bankAccountEntity.Balance, state.Balance);
        }

        [Fact]
        public void GeneralTests()
        {
            Assert.Throws<Exception>(() => bankAccount.Status.Freeze(string.Empty));

            bankAccount.Status.Freeze("Fraud detected.");
            Assert.True(bankAccountEntity.Frozen);

            Assert.Throws<Exception>(() => bankAccount.Deposit(100m));
            Assert.Throws<Exception>(() => bankAccount.Withdraw(100m));

            bankAccount.Status.Unfreeze();
            Assert.False(bankAccountEntity.Frozen);

            bankAccount.Deposit(100m);
            Assert.Equal(1100m, bankAccountEntity.Balance);

            bankAccount.Withdraw(100m);
            Assert.Equal(1000m, bankAccountEntity.Balance);
        }
    }
}
