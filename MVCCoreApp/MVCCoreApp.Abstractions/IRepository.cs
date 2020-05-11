﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCCoreApp.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> DeleteAsync(Guid id);
    }
}
