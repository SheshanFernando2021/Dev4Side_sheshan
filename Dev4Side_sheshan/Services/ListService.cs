using Dev4Side_sheshan.Models;
using Dev4Side_sheshan.Repos;

namespace Dev4Side_sheshan.Services
{
    public class ListService : IListService
    {
        private readonly IListRepo _listRepo;

        public ListService(IListRepo listRepo)
        {
            _listRepo = listRepo;
        }

        public async Task<ListEntity> CreateList(ListEntity listEntity)
        {
            return await _listRepo.createList(listEntity);
        }

        public async Task DeleteList(int userId, int listId)
        {
            var list = await _listRepo.getOneList(listId, userId);
            if (list == null) {
                throw new Exception("no list found to delete");
            }
            await _listRepo.deleteList(listId, userId);
        }

        public async Task<List<ListEntity>> GetListsAsync(int userId)
        {
            var list = await _listRepo.getAllListAsync(userId);
            if (list == null)
            {
                throw new NotImplementedException("no lists found for this user");
            }
            return list;
        }
    }
}
