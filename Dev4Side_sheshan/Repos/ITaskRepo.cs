using Dev4Side_sheshan.Models;

namespace Dev4Side_sheshan.Repos
{
    public interface ITaskRepo
    {
        Task<TaskEntity> getById (int id);
        Task<List<TaskEntity>> getAllByUserId (int userId);
        Task<List<TaskEntity>> getAllByList(int listId, int userId);
        Task<TaskEntity> createTask(TaskEntity taskEntity);
        Task<TaskEntity> updateTask(TaskEntity taskEntity);
        Task deleteTask (int id);
    }
}
