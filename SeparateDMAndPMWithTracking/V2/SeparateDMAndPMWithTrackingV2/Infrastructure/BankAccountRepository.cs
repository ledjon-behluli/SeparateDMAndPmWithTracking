using Microsoft.EntityFrameworkCore;
using SeparateDMAndPMWithTrackingV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeparateDMAndPMWithTrackingV2.Infrastructure
{
    public class BankAccountRepository
    {
        private readonly DbContext _context;

        public BankAccountRepository(DbContext context)
        {
            _context = context;
        }

        public BankAccount Get(Guid id)
        {
            var entity = _context.BankAccounts.FirstOrDefault(x => x.Id == id);
            return new BankAccount(entity);
        }

        public void Add(BankAccount account)
        {
            var entity = account.GetState();
            _context.BankAccounts.Add(entity);
            _context.SaveChanges();
        }

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var entity = _context.BankAccounts.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.BankAccounts.Remove(entity);
                _context.SaveChanges();
            }
        }

        public class DbContext : Microsoft.EntityFrameworkCore.DbContext
        {
            public DbSet<IBankAccountState> BankAccounts { get; set; }
        }
    }
}
