using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD_CW.DAL.DBO;

namespace WAD_CW.DAL.Repositories
{
    public class CourierRepo : BaseRepo, IRepository<Courier>
    {

        public CourierRepo(AddOrderDbContext context): base(context) { }

        public async Task CreateAsync(Courier entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        //Вернуться если что то не будет работать
        public async Task DeleteAsync(int id)
        {
            var  courier = await _context.Couriers.FindAsync(id);
            _context.Couriers.Remove(courier);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Courier>> GetAllAsync()
        {
            return await _context.Couriers.ToListAsync();
        }

        public Task<Courier> GetByIdAsync(int id)
        {
            return _context.Couriers
                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Courier entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Couriers.Any(e => e.Id == id);
        }
    }
}
