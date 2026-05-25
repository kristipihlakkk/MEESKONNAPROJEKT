using Common;
using Gym.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;


namespace Gym.Infra;

public abstract class BaseRepo<T> : IRepo<T> where T : BaseEntity {
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepo(AppDbContext context) {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetAsync(Guid id)
        => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

    public virtual async Task<int> CountAsync(Query query)
        => await _dbSet.CountAsync();

    public virtual async Task<IEnumerable<T>> GetAsync(Query query)
        => await _dbSet.ToListAsync();

    public virtual async Task<T> CreateAsync(T entity) {
        entity.ValidFrom = DateTime.UtcNow;
        entity.ValidTo = DateTime.UtcNow;
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity) {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task DeleteAsync(Guid id) {
        var entity = await GetAsync(id);
        if (entity is not null) {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}