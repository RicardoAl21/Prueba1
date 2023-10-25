using BackApi.Models;
using BackApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BackApi.Services.Implementation
{
    public class UserService : IUserService
    {
        private PruebaContext _context;

        public UserService(PruebaContext context)
        {   
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                List<User> lis = new List<User>();
                lis = await _context.Users.Include(dpt => dpt.IdDepartamentoNavigation).Include(crg => crg.IdCargoNavigation).ToListAsync();
                return lis;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<User>> GetUsersByCargo(int cargo)
        {
            try
            {
                List<User> lista = new List<User>();
                lista = await _context.Users
                    .Include(dpt => dpt.IdDepartamentoNavigation)
                    .Include(crg => crg.IdCargoNavigation)
                    .Where(c => c.IdCargoNavigation.IdCargo == cargo)
                    .ToListAsync();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<List<User>> GetUsersByDepartamento(int departamento)
        {
            try
            {
                List<User> list = new List<User>();
                list = await _context.Users
                .Include(dpt => dpt.IdDepartamentoNavigation)
                .Include(crg => crg.IdCargoNavigation)
                .Where(d => d.IdDepartamentoNavigation.IdDepartamento == departamento)
                .ToListAsync();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<User> GetUser(int IdUser)
        {
            try
            {
                User? encontrado = new User();

                encontrado = await _context.Users.
                    Include(dpt => dpt.IdDepartamentoNavigation).
                    Include(crg => crg.IdCargoNavigation).
                    Where(e => e.IdUser == IdUser).FirstOrDefaultAsync();

                return encontrado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Add(User modelo)
        {
            try
            {
                _context.Users.Add(modelo);
                await _context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> Update(User modelo)
        {
            try
            {
                _context.Users.Update(modelo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(User modelo)
        {
            try
            {
                _context.Users.Remove(modelo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
