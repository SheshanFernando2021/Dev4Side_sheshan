using Dev4Side_sheshan.DTOs;
using Dev4Side_sheshan.Models;
using Dev4Side_sheshan.Repos;

namespace Dev4Side_sheshan.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepo _taskRepo;
        private readonly IListRepo _listRepo;

        public TaskService(ITaskRepo taskRepo, IListRepo listRepo)
        {
            _taskRepo = taskRepo;
            _listRepo = listRepo;
        }

        public async Task<TaskEntity> createTask(TaskDTO dto, int userid)
        {
            
            var list = await _listRepo.getOneList(dto.ListId, userid);
            if (list == null || list.UserId != userid)
            {
                throw new UnauthorizedAccessException("Cannot add task to this list");
            }

            var task = new TaskEntity
            {
                Name = dto.Name,
                DueDate = dto.DueDate,
                Description = dto.Description,
                Status = dto.Status,
                ListId = dto.ListId
            };

            return await _taskRepo.createTask(task);
        }



        public async Task deleteTask(int id, int userId)
        {
            var task = await _taskRepo.getById(id);
            if(task == null || task.ListEntity.UserId != userId)
            {
                throw new UnauthorizedAccessException("Task not found for the user");
            }
            await _taskRepo.deleteTask(id);
        }

        public async Task<List<TaskEntity>> getAllTasks(int userId)
        {
            return await _taskRepo.getAllByUserId(userId);
        }

        //public async Task<List<TaskEntity>> getAllTasksbyListId(int listId, int userId, UserEntity userEntity)
        //{
        //    var list = await _listRepo.getOneList(listId, userId);
        //    if (list == null) {
        //        throw new Exception($"List not found for {userEntity.Email}");
        //    }
        //    return await _taskRepo.getAllByList(listId, userId);
        //}
        public async Task<List<TaskDTO>> getAllTasksbyListId(int listId, int userId, UserEntity userEntity)
        {
            var list = await _listRepo.getOneList(listId, userId);
            if (list == null)
            {
                throw new Exception($"List not found for {userEntity.Email}");
            }

            var tasks = await _taskRepo.getAllByList(listId, userId);

            return tasks.Select(task => new TaskDTO
            {
                TaskId = task.TaskId,
                Name = task.Name,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status,
                ListId = task.ListId
            }).ToList();
        }


        public Task<TaskEntity> getTaskById(int taskId)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskEntity> updateTask(int taskId, TaskEntity taskEntity, int userid)
        {
            var existingTask = await _taskRepo.getById(taskId);
            if (existingTask == null || existingTask.ListEntity.UserId != userid) {
                throw new UnauthorizedAccessException("Task not found for the user");
            }
            existingTask.Name = taskEntity.Name;
            existingTask.ListId = taskEntity.ListId;
            existingTask.Description = taskEntity.Description;
            existingTask.Status = taskEntity.Status;
            existingTask.DueDate = taskEntity.DueDate;

            await _taskRepo.updateTask(existingTask);
            return existingTask;
             
        }
    }
}
