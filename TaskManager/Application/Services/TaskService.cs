using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title) || task.Title.Length > 100)
                throw new ArgumentException("Title is required and must be at most 100 characters.");

            if (task.CompletedAt.HasValue && task.CompletedAt < task.CreatedAt)
                throw new ArgumentException("CompletedAt cannot be earlier than CreatedAt.");

            return await _repository.CreateAsync(task);
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TaskItem?> UpdateAsync(TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title) || task.Title.Length > 100)
                throw new ArgumentException("Title is required and must be at most 100 characters.");

            if (task.CompletedAt.HasValue && task.CompletedAt < task.CreatedAt)
                throw new ArgumentException("CompletedAt cannot be earlier than CreatedAt.");

            return await _repository.UpdateAsync(task);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
