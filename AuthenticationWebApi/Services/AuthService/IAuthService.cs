namespace AuthenticationWebApi.Services.AuthService
{
    public interface IAuthService
    {
        Task<User> CreateUser(UserDto request);
        Task<AuthResponseDto> Login(UserDto request);
        Task<AuthResponseDto> RefreshToken();
    }
}
