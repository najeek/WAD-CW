using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD_CW.DAL.Repositories
{
    public abstract class BaseRepo
    {
        protected readonly AddOrderDbContext _context;

        protected BaseRepo(AddOrderDbContext context)
        {
            _context = context;

        }
    }
}
