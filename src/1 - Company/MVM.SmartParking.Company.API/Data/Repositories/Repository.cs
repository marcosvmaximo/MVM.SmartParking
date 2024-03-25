using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MVM.SmartParking.Company.API.Models.Base;
using MVM.SmartParking.Data.Core;

namespace MVM.SmartParking.Company.API.Data;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseModel
{
    protected readonly DataContext _context;
    private readonly Logger<Repository<TEntity>> _logger;

    public Repository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TEntity?>> GetByFilter(Expression<Func<TEntity, bool>> filter)
    {
        return _context.Set<TEntity>().Where(filter);
    }

    public async Task<IEnumerable<TEntity?>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task Add(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task Update(TEntity entity)
    {        
        _context.Set<TEntity>().Update(entity);
    }

    public async Task Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
}