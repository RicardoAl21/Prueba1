using BackApi.Models;

namespace BackApi.Services.Contracts
{
    public interface ICargoService
    {
        Task<List<Cargo>> GetCargos();
    }
}
