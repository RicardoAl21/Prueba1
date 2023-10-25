using BackApi.Models;
using Microsoft.AspNetCore.SignalR;

namespace BackApi.Services.Contracts
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        Task<List<User>> GetUsersByCargo(int cargo);

        Task<List<User>> GetUsersByDepartamento(int departamento);

        Task<User> GetUser(int IdUser);

        Task<User> Add(User modelo);

        Task<bool> Update(User modelo);

        Task<bool> Delete(User modelo);
    }
}
