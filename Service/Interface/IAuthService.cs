using LogisticMVP.Models;
using LogisticMVP.Response;

namespace LogisticMVP.Service.Interface;

public interface IAuthService
{
    public Task<ServiceResponse<User>> Login(string name, string password);
    public Task<ServiceResponse<User>> RegisterUser(User user);
    public Task<ServiceResponse<User>> RegisterDriver(User user);
}