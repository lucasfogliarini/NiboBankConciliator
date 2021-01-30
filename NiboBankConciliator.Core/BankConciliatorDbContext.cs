using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NiboBankConciliator.Core
{
    internal class BankConciliatorDbContext : DbContext
    {
        //public BankConciliatorDbContext(DbContextOptions<BankConciliatorDbContext> options) : base(options)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(thisAssembly);
        }
    }
}
