using Dev4Side_sheshan.DTOs;

namespace Dev4Side_sheshan.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(UserRegisterDTO userRegisterDTO);
        Task<string>LoginAsync(UserLoginDTO userLoginDTO);
    }
}
