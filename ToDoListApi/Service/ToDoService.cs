using System;
using ToDoListApi.Interface;
using ToDoListApi.Interfaces;
using ToDoListApi.Models;

namespace ToDoListApi.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ToDoItem> AddAsync(string title, string description)
        {
            var item = new ToDoItem
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description
            };
            await _repository.CreateAsync(item);
            return item;
        }
        // Additional business logic methods...
    }
}

