using System;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Interface;
using ToDoListApi.Models;

namespace ToDoListApi.Data
{
    public class EfToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _dbContext;

        public EfToDoRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ToDoItem> GetByIdAsync(Guid id)
        {
            return await _dbContext.ToDoItems.FindAsync(id);
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _dbContext.ToDoItems.ToListAsync();
        }

        public async Task CreateAsync(ToDoItem item)
        {
            _dbContext.ToDoItems.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            _dbContext.ToDoItems.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _dbContext.ToDoItems.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}

