using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Gym.Infra;

public interface IRepo<T> where T : BaseEntity
    {
    Task<T> GetAsync(Guid id);

    Task<IEnumerable<T>> GetAsync();

    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(Guid id);
}