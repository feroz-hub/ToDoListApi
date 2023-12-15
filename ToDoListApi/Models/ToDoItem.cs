using System;
namespace ToDoListApi.Models
{
    // ToDoItem represents a single item in the to-do list.
    public class ToDoItem
    {
        // Unique identifier for each to-do item.
        public Guid Id { get; set; }

        // Title or name of the to-do item.
        public string Title { get; set; }

        // Detailed description or additional information about the to-do item.
        public string Description { get; set; }

        // Flag indicating whether the to-do item is marked as completed.
        public bool Completed { get; set; }
    }

}

