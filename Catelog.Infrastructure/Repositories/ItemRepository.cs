using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catelog.Domain.Entities;
using Catelog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Catelog.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly CatelogContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ItemRepository(CatelogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Item Add(Item item)
        {
            return _context.Items.Add(item).Entity;
        }

        public async Task<IEnumerable<Item>> GetAsync()
        {
            return await _context.Items.AsNoTracking().ToListAsync();
        }

        public async Task<Item> GetAsync(Guid id)
        {
            var item = await _context.Items.AsNoTracking().Where(x => x.Id == id).Include(x => x.Genre).Include(x => x.Artist).FirstOrDefaultAsync();
            return item;
        }

        public Item Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
