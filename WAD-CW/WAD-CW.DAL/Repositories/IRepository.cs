﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW.DAL.Repositories
{
    public interface IRepository<T> where T:class
    {
        bool Exists(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
