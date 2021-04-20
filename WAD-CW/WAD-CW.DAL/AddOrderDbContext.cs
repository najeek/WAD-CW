using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_CW.DAL.DBO;

namespace WAD_CW.DAL
{
    public class AddOrderDbContext: DbContext
    {
        public AddOrderDbContext(DbContextOptions<AddOrderDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }
    }
}
