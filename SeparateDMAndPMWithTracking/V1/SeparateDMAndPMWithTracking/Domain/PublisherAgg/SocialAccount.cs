using System;
using System.Collections.Generic;
using System.Text;

namespace SeparateDMAndPMWithTracking.Domain.PublisherAgg
{
    public class SocialAccount
    {
        public SocialAccountId Id { get; private set; }
        public string Email { get; private set; }
        public AccountType AccountType { get; private set; }

        public SocialAccount(SocialAccountId id, string email, AccountType type) 
        {
            this.Id = id;
            this.Email = email;
            this.AccountType = type;
        }

        /// <summary>
        /// Only accessible by the aggregate root
        /// </summary>
        internal void ChangeAccountType(AccountType type)
        {
            // Business Rules ...
            if (AccountType == type)
                throw new Exception($"Account already is of type {type}");

            AccountType = type;
        }

        /// <summary>
        /// Only accessible by the aggregate root
        /// </summary>
        internal void ChangeEmail(string email)
        {
            // Guards
            if (string.IsNullOrEmpty(email))
                throw new Exception("Email can not be null!");

            // Business Rules...
            if (!email.Contains('@'))
                throw new Exception("Valid email requires '@' symbol");

            Email = email;
        }
    }
}
