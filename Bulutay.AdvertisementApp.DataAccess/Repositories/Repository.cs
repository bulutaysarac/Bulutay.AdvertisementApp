using Bulutay.AdvertisementApp.Common.Enums;
using Bulutay.AdvertisementApp.DataAccess.Contexts;
using Bulutay.AdvertisementApp.DataAccess.Interfaces;
using Bulutay.AdvertisementApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulutay.AdvertisementApp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AdvertisementAppContext _context;

        public Repository(AdvertisementAppContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>()
                .Where(filter)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {   
            if (orderByType == OrderByType.ASC)
            {
                return await _context.Set<T>()
                    .OrderBy(selector)
                    .AsNoTracking()
                    .ToListAsync();
            }
            return await _context.Set<T>()
                .OrderByDescending(selector)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            if (orderByType == OrderByType.ASC)
            {
                return await _context.Set<T>()
                    .Where(filter)
                    .OrderBy(selector)
                    .AsNoTracking()
                    .ToListAsync();
            }
            return await _context.Set<T>()
                .Where(filter)
                .OrderByDescending(selector)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            if(asNoTracking)
            {
                return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
            }
            return await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
