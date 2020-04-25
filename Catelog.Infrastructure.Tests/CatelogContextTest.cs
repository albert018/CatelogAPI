using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Catelog.Domain.Entities;
using Catelog.Infrastructure.Tests.Extensions;

namespace Catelog.Infrastructure.Tests
{
    public class CatelogContextTest:CatelogContext
    {
        public CatelogContextTest(DbContextOptions<CatelogContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Seed<Artist>("./Data/Artist.json");
            builder.Seed<Genre>("./Data/Genre.json");
            builder.Seed<Item>("./Data/Item.json");
        }
    }
}
