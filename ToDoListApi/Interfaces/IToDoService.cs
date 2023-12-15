using System;
using ToDoListApi.Models;

namespace ToDoListApi.Interfaces
{
	public interface IToDoService
	{
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task<ToDoItem> GetByIdAsync(Guid id);
        Task<ToDoItem> AddAsync(string title, string description);
    }
}

