using Dev4Side_sheshan.Data;
using Dev4Side_sheshan.Models;
using Microsoft.EntityFrameworkCore;

namespace Dev4Side_sheshan.Repos
{
    public class UserRepo: IUserRepo
    {
        private readonly AppDbContext _db;

        public UserRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task<UserEntity> createAsync(UserEntity user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntity> getUserName(string userName)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == userName);
        }
    }
}
