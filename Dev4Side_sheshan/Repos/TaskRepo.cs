using Dev4Side_sheshan.Data;
using Dev4Side_sheshan.Models;
using Microsoft.EntityFrameworkCore;

namespace Dev4Side_sheshan.Repos
{    
    public class TaskRepo : ITaskRepo
    {
        private readonly AppDbContext _db;

        public TaskRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TaskEntity> createTask(TaskEntity taskEntity)
        {
            _db.Tasks.Add(taskEntity);
            await _db.SaveChangesAsync();
            return taskEntity;
        }

        public async Task deleteTask(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task != null)
            {
                _db.Tasks.Remove(task);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<TaskEntity>> getAllByList(int listId, int userId)
        {
            return await _db.Tasks.Include(l => l.ListEntity)
                                  .Where(t => t.ListId == listId && t.ListEntity.UserId == userId)
                                  .ToListAsync();
        }

        public async Task<List<TaskEntity>> getAllByUserId(int userId)
        {
            return await _db.Tasks.Include(l => l.ListEntity)
                                     .Where(t => t.ListEntity.UserId == userId)
                                     .ToListAsync();
        }

        public async Task<TaskEntity> getById(int id)
        {
            return await _db.Tasks.Include(l => l.ListEntity)
                                  .FirstOrDefaultAsync(t => t.TaskId == id);
        }

        public async Task<TaskEntity> updateTask(TaskEntity taskEntity)
        {
            _db.Tasks.Update(taskEntity);
            await _db.SaveChangesAsync();
            return taskEntity;
        }
    }
}
