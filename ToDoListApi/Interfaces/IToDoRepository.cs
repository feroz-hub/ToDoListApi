using System;
using ToDoListApi.Models;

namespace ToDoListApi.Interface
{
	public interface IToDoRepository
	{
        Task<ToDoItem> GetByIdAsync(Guid id);
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task CreateAsync(ToDoItem item);
        Task UpdateAsync(ToDoItem item);
        Task DeleteAsync(Guid id);

    }
}

