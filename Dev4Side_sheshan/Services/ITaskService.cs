using Dev4Side_sheshan.Models;

namespace Dev4Side_sheshan.Services
{
    public interface ITaskService
    {
        Task<List<TaskEntity>> getAllTasks(int userId);
        Task<TaskEntity> getTaskById(int taskId);
        Task<List<TaskEntity>> getAllTasksbyListId(int listId , int userId, UserEntity userEntity);
        Task<TaskEntity> createTask(TaskEntity taskEntity, int userid);
        Task<TaskEntity> updateTask(int taskId, TaskEntity taskEntity, int userid);
        Task deleteTask(int id, int userId);
    }
}
