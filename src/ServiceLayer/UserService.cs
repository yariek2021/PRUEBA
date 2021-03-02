using AutoMapper;
using CommonLayer;
using DomainLayer;
using DtoLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersistenceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IUserService
    {
        Task<UsuarioDto> Authenticate(string username, string password);
        Task<IEnumerable<UsuarioDto>> GetAllUsers();
        Task<UsuarioDto> GetUsuario(int id);
        Task<List<RoleDto>> GetRoles();
        Task<RoleDto> GetRoleByid(int Id);
        Task<List<string>> GetUsersInRoleAsync(int Id);
        Task<bool> IsInRoleAsync(int UsuarioId, int RoleId);
        Task<ResponseHelper> CreateRole(RoleCreateDto model);
       Task<int> UserRoleAsync(int UsuarioId);
        Task<ResponseHelper> InsertOrUpdateUsuarioRole(UsuarioRoleUpdate model, UsuarioAccesoUpdateDto acceso);
        Task<bool> AccesoSistemaUsuario(int UsuarioId);
    }


    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public UserService(
            ApplicationDbContext context,
            ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<UsuarioDto> GetUsuario(int id)
        {
            var result = new UsuarioDto();

            try
            {

                result = await (from u in _context.Usuarios                               
                                where u.UsuarioId == id
                              select new UsuarioDto
                              {
                                  UsuarioId = u.UsuarioId,
                                  Alias = u.Alias,
                                  NombreUsuario = u.NombreUsuario,
                                  Acceso = u.Acceso
                              }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ResponseHelper> InsertOrUpdateUsuarioRole(UsuarioRoleUpdate model, UsuarioAccesoUpdateDto acceso)
        {
            var result = new ResponseHelper();

            try
            {
                var originalEntry = await _context.UsuariosRoles.SingleOrDefaultAsync(x => x.UsuarioId == model.UserId);

                var originalAcceso = await _context.UsuariosAcceso.SingleOrDefaultAsync(x => x.UserId == model.UserId);

                using (var trx = _context.Database.BeginTransaction())
                {

                    try
                    {
                        //Role
                        if (originalEntry != null)
                        {
                            _context.UsuariosRoles.Remove(originalEntry);

                        }

                        var entry = Mapper.Map<UsuarioRole>(model);
                        await _context.AddAsync(entry);

                        //Acceso

                        if (originalAcceso != null)
                        {
                            _context.UsuariosAcceso.Remove(originalAcceso);

                        }

                        var entryAcceso = Mapper.Map<UsuarioAcceso>(acceso);
                        await _context.AddAsync(entryAcceso);

                        await _context.SaveChangesAsync();

                        trx.Commit();

                        result.IsSuccess = true;
                    }
                    catch (Exception x)
                    {
                        trx.Rollback();
                    }

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }
        public async Task<UsuarioDto> Authenticate(string username, string password)
        {
            UsuarioDto user = null;

            try
            {
                user = await (from u in _context.Usuarios
                              join ur in _context.UsuariosRoles on u.UsuarioId equals ur.UsuarioId
                              join r in _context.Roles on ur.RoleId equals r.Id
                              where u.NombreUsuario == username && u.Contra == password && u.Acceso == true
                              select new UsuarioDto
                              {
                                  UsuarioId = u.UsuarioId,
                                  Alias = u.Alias,
                                  NombreUsuario = u.NombreUsuario,
                                  Role = r.Name,
                                  Acceso = u.Acceso
                              }).FirstOrDefaultAsync();

                if (user == null)
                    return null;

                user.Contra = null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return user;
        }

        public async Task< IEnumerable<UsuarioDto>> GetAllUsers()
        {

            var user = new List<UsuarioDto>();
     
            try
            {
                 user = await (from u in _context.Usuarios
                               join ur in _context.UsuariosRoles on u.UsuarioId equals ur.UsuarioId
                               join r in _context.Roles on ur.RoleId equals r.Id
                              select new UsuarioDto
                              {
                                  UsuarioId = u.UsuarioId,
                                  Alias = u.Alias,
                                  NombreUsuario = u.NombreUsuario,
                                  Contra = null,
                                  Acceso = u.Acceso,
                                  Role = r.Name
                              }).OrderBy(x => x.Alias).ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return user;

        }

        public async Task<List<RoleDto>> GetRoles()
        {

            var result = new List<RoleDto>();

            try
            {
                var records = await _context.Roles.ToListAsync();
                result = Mapper.Map<List<RoleDto>>(records);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;

        }

        public async Task<RoleDto> GetRoleByid(int Id)
        {

            var result = new RoleDto();

            try
            {
                var records = await _context.Roles.FirstOrDefaultAsync(x=> x.Id == Id);
                result = Mapper.Map<RoleDto>(records);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;

        }

        public async Task<List<string>> GetUsersInRoleAsync(int Id)
        {
           // var user = new List<string>();
            List<string> user = null;

            try
            {
                user = await (from u in _context.Usuarios
                                    join r in _context.UsuariosRoles on u.UsuarioId equals r.UsuarioId
                                    where r.RoleId == Id
                                    select u.Alias).ToListAsync();

           //     user = records.to

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return user;
        }

        public async Task<bool> IsInRoleAsync(int UsuarioId, int RoleId)
        {
            bool result = false;

            try
            {
                var records = await _context.UsuariosRoles.FirstOrDefaultAsync(x => x.UsuarioId == UsuarioId && x.RoleId == RoleId);
               
                if(records != null)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<int> UserRoleAsync(int UsuarioId)
        {
            int result = 0;

            try
            {
                var records = await _context.UsuariosRoles.FirstOrDefaultAsync(x => x.UsuarioId == UsuarioId);

                if (records != null)
                {
                    result = records.RoleId;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }


        public async Task<ResponseHelper> CreateRole(RoleCreateDto model)
        {
            var result = new ResponseHelper();

            try
            {
                var entry = Mapper.Map<Role>(model);

                await _context.AddAsync(entry);
                await _context.SaveChangesAsync();


                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<bool> AccesoSistemaUsuario(int UsuarioId)
        {
            bool result = false;

            try
            {
                var records = await _context.UsuariosAcceso.FirstOrDefaultAsync(x => x.UserId == UsuarioId);

                if (records != null)
                {
                    result = records.Activo;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

    }



  
}
