using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Catelog.Domain.Entities;
using Catelog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Catelog.Infrastructure
{
    public class CatelogContext : DbContext, IUnitOfWork
    {
        public const string _defaultSchema = "catelog";

        public DbSet<Item> Items { get; set; }

        public CatelogContext(DbContextOptions<CatelogContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
