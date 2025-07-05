using Dev4Side_sheshan.Models;

namespace Dev4Side_sheshan.Repos
{
    public interface IUserRepo
    {
        Task<UserEntity> createAsync(UserEntity user);
        Task<UserEntity> getUserName(string userName);
    }
}
