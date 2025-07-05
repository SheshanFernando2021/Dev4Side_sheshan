using Dev4Side_sheshan.Models;

namespace Dev4Side_sheshan.Services
{
    public interface IListService
    {
        Task<List<ListEntity>> GetListsAsync(int userId);
        Task<ListEntity> CreateList(ListEntity listEntity);
        Task DeleteList (int userId, int listId);
    }
}
