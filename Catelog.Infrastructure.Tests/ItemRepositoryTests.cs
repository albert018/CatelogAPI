using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;
using Catelog.Infrastructure.Repositories;

namespace Catelog.Infrastructure.Tests
{
    public class ItemRepositoryTests
    {
        [Fact]
        public async Task should_get_data()
        {
            var options = new DbContextOptionsBuilder<CatelogContext>()
                .UseInMemoryDatabase(databaseName: "should_get_data")
                .Options;

            await using var context = new CatelogContextTest(options);
            context.Database.EnsureCreated();

            var sut = new ItemRepository(context);
            var result = await sut.GetAsync();

            result.ShouldNotBeNull();
        }
    }
}
