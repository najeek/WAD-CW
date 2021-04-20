using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD_CW.DAL.DBO;

namespace WAD_CW.DAL.Repositories
{
    public class OrderRepo : BaseRepo, IRepository<Order>
    {
        public OrderRepo(AddOrderDbContext context):base(context) { }

        public async Task CreateAsync(Order entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(o => o.Courier).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                   .Include(o => o.Courier)
                   .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Orders.Any(p => p.Id == id);
        }
    }
}
