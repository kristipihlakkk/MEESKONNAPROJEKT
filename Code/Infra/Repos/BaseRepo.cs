using Gym.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Infra;

public abstract class BaseRepo<T> : IRepo<T>
    where T : BaseEntity
{
    protected readonly AppDbContext Db;

    protected BaseRepo(AppDbContext db)
    {
        Db = db;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await Db.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Db.Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        Db.Set<T>().Add(entity);

        await Db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        Db.Set<T>().Update(entity);

        await Db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        if (entity != null)
        {
            Db.Set<T>().Remove(entity);

            await Db.SaveChangesAsync();
        }
    }
}
