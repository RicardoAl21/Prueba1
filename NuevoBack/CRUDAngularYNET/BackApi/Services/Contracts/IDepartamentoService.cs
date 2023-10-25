using BackApi.Models;

namespace BackApi.Services.Contracts
{
    public interface IDepartamentoService
    {
        Task<List<Departamento>> GetDepartamentos();
    }
}
