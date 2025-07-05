using Dev4Side_sheshan.Models;

namespace Dev4Side_sheshan.Repos
{
    public interface IListRepo
    {
        Task<List<ListEntity>> getAllListAsync(int userId);
        Task<ListEntity> getOneList(int listId, int userId);
        Task<ListEntity> createList(ListEntity listEntity, int userId);
        Task<ListEntity> updateList(ListEntity listEntity);
        Task deleteList (int listId, int userId);
    }
}
