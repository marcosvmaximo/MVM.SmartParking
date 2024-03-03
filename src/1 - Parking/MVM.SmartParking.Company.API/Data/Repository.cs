using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using MVM.SmartParking.Company.API.Models.Base;
using MVM.SmartParking.Core;

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

    public async Task<IEnumerable<TEntity?>> GetAll()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
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