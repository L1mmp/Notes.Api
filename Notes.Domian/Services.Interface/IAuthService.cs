using Notes.Domian.Models;
using System.Threading.Tasks;

namespace Notes.Domian.Services.Interface
{
    public interface IAuthService
    {
        public string Login(User user);

        public Task<User> Register(User user);

        public string GenerateJWTToken(string secretKey, User user);

    }
}
