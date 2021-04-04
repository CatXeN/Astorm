using System.Collections.Generic;
using System.Threading.Tasks;
using AstormApplication.Interfaces;
using AstormPresistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AstormPresistance.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T: class
    {
        private readonly DataContext _context;

        public GenericRepositoryAsync(DataContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public virtual async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
    }
}