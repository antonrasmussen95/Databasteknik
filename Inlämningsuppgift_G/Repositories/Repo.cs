using Inlämningsuppgift_G.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Inlämningsuppgift_G.Repositories;

internal abstract class Repo<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected Repo(DataContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
      try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return entity ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
           return await _context.Set<TEntity>().AnyAsync(expression);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
      
    }

    public async virtual Task<TEntity> GetSpecificAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return entity ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }

    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }


}

