using Dev4Side_sheshan.Models;
using Dev4Side_sheshan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dev4Side_sheshan.Controllers
{
    [Route("tasks")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new Exception("UserId not found"));
        private UserEntity GetUser() => new UserEntity
        {
            Email = User.FindFirst(ClaimTypes.Email)?.Value ?? "unknown@example.com",
            UserId = GetUserId()
        };
        public TaskController(ITaskService taskService  )
        {
            _taskService = taskService;
        }

        
        
        
        [HttpGet("{listId}")]
        public async Task<IActionResult> GetTasksByListId(int listId)
        {
            var userId = GetUserId();
            var Tasks = await _taskService.getAllTasksbyListId(listId, userId, GetUser());
            return Ok(Tasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskEntity taskEntity)
        {
            var userId = GetUserId();
            var createTask = await _taskService.createTask(taskEntity, userId);
            return Ok(createTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id,[FromBody] TaskEntity taskEntity)
        {
            var userId = GetUserId();
            var updatedTask = await _taskService.updateTask(id, taskEntity, userId);
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var userId = GetUserId();
            await _taskService.deleteTask(id, userId);
            return NoContent();
        }
    }
}
