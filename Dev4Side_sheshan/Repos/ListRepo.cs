using Dev4Side_sheshan.Data;
using Dev4Side_sheshan.Models;
using Microsoft.EntityFrameworkCore;

namespace Dev4Side_sheshan.Repos
{
    public class ListRepo : IListRepo
    {
        private readonly AppDbContext _db;

        public ListRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ListEntity> createList(ListEntity listEntity)
        {
            _db.Lists.Add(listEntity);
            await _db.SaveChangesAsync();
            return listEntity;
        }

        public async Task deleteList(int listId, int userId)
        {
            var list = await getOneList(listId, userId);
            if (list != null)
            {
                _db.Lists.Remove(list);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<ListEntity>> getAllListAsync(int userId)
        {
            return await _db.Lists
                            .Where(l => l.UserId == userId)
                            .ToListAsync();
        }

        public async Task<ListEntity> getOneList(int listId , int userId)
        {
            return await _db.Lists
                            .FirstOrDefaultAsync(l => l.UserId == userId && l.ListId == listId);
        }

        public async Task<ListEntity> updateList(ListEntity listEntity)
        {
           _db.Lists.Update(listEntity);
            await _db.SaveChangesAsync();
            return listEntity;
        }
    }
}
