using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Services;
using TaskManager.Domain.Entities;
using TaskManager.Presentation.DTOs;

namespace TaskManager.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                CompletedAt = dto.CompletedAt,
                Status = dto.Status
            };

            if (entity.CompletedAt.HasValue && entity.CompletedAt < entity.CreatedAt)
            {
                ModelState.AddModelError("CompletedAt", "Data de conclusão não pode ser anterior à data de criação.");
                return BadRequest(ModelState);
            }

            var created = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest("Id mismatch");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (dto.CompletedAt.HasValue && dto.CompletedAt < dto.CreatedAt)
            {
                ModelState.AddModelError("CompletedAt", "Data de conclusão não pode ser anterior à data de criação.");
                return BadRequest(ModelState);
            }

            var entity = new TaskItem
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt,
                CompletedAt = dto.CompletedAt,
                Status = dto.Status
            };

            var updated = await _service.UpdateAsync(entity);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
