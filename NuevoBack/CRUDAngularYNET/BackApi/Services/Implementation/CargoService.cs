using BackApi.Models;
using BackApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BackApi.Services.Implementation
{
    public class CargoService : ICargoService
    {
        private PruebaContext _dbContext;
        public CargoService(PruebaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cargo>> GetCargos()
        {
            try
            {
                List<Cargo> lista = new List<Cargo>();
                lista = await _dbContext.Cargos.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
