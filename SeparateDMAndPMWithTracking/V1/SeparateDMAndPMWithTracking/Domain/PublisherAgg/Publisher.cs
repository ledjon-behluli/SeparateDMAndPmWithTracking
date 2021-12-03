using SeparateDMAndPMWithTracking.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeparateDMAndPMWithTracking.Domain.PublisherAgg
{
    /// <summary>
    /// Publisher is chosen as the AggRoot since a SocialAccount can exists without a Publisher.
    /// Yet a publisher has sense only if it has to publish something (SocialAccount in our case).
    /// So the publisher contains a list of SocialAccounts, whereas SocialAccount doesn't have a reference
    /// to Publisher.
    /// </summary>
    public class Publisher : IAggregateRoot
    {
        public PublisherId Id { get; private set; }
        public string Name { get; private set; }


        private readonly List<SocialAccount> _assignedSocialAccounts;
        public IReadOnlyList<SocialAccount> AssignedSocialAccounts => _assignedSocialAccounts.AsReadOnly();

        public Publisher(PublisherId id, string name, List<SocialAccount> assignedSocialAccounts)
        {
            this.Id = id;
            this.Name = name;
            this._assignedSocialAccounts = assignedSocialAccounts;
        }

        public void AssignSocialAccount(SocialAccount account)
        {
            // Guards
            if (account == null)
                throw new Exception("SocialAccount can not be null!");

            // Business Rules ...
            if (_assignedSocialAccounts.Contains(account))
                throw new Exception("Account already assigned!");

            _assignedSocialAccounts.Add(account);
        }

        public void ChangePublisherName(string name)
        {
            // Guards
            if (string.IsNullOrEmpty(name))
                throw new Exception("Publisher must have a name!");

            // Business Rules ...
            // Any rules you want to enforce.

            this.Name = name;
        }

        public void ChangeAccountType(SocialAccount account, AccountType type) => account.ChangeAccountType(type);

        public void ChangeAccountEmail(SocialAccount account, string email) => account.ChangeEmail(email);
    }
}
