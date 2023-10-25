using BackApi.Models;
using BackApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BackApi.Services.Implementation
{
    public class DepartamentoService : IDepartamentoService
    {
        private PruebaContext _dbcontxt;

        public DepartamentoService(PruebaContext dbContxt)
        {
            _dbcontxt = dbContxt;
        }

        public async Task<List<Departamento>> GetDepartamentos()
        {
            try
            {
                List<Departamento> list = new List<Departamento>();
                list = await _dbcontxt.Departamentos.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
