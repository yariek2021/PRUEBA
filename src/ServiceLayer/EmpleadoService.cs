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
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoDto>> GetEmpleados();
        Task<EmpleadoBaseDto> GetEmpleadoById(int EmpleadoId);
        Task<ResponseHelper> Create(EmpleadoBaseDto model);
        Task<ResponseHelper> Update(EmpleadoBaseDto model);
    }
    public class EmpleadoService: IEmpleadoService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public EmpleadoService(
            ApplicationDbContext context,
            ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task<IEnumerable<EmpleadoDto>> GetEmpleados()
        {

            var empleado = new List<EmpleadoDto>();

            try
            {
                empleado = await (from e in _context.Empleados
                              join p in _context.Puestos on e.PuestoId equals p.PuestoId
                              join d in _context.Departamentos on p.DepartamentoId equals d.DepartamentoId
                              select new EmpleadoDto
                              {
                                  EmpleadoId = e.EmpleadoId,
                                  Nombre = e.Nombre,
                                  ApellidoPaterno = e.ApellidoPaterno,
                                  ApellidoMaterno = e.ApellidoMaterno,
                                  FechaNacimiento = e.FechaNacimiento,
                                  Direccion = e.Direccion,
                                  Telefono = e.Telefono,
                                  Email = e.Email,
                                  NSS = e.NSS,
                                  PuestoId = e.PuestoId,
                                  FechaIngreso = e.FechaIngreso,
                                  FechaBaja = e.FechaBaja,
                                  Estatus = e.Estatus,
                                  Departamento = d.Nombre,
                                  Puesto = p.Nombre
                              }).OrderBy(x => x.Nombre).ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return empleado;

        }

        public async Task<EmpleadoBaseDto> GetEmpleadoById(int EmpleadoId)
        {
            var result = new EmpleadoBaseDto();

            try
            {
                var records = await _context.Empleados.FirstOrDefaultAsync(x => x.EmpleadoId == EmpleadoId);
                result = Mapper.Map<EmpleadoBaseDto>(records);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ResponseHelper> Create(EmpleadoBaseDto model)
        {
            var result = new ResponseHelper();

            try
            {
                var entry = Mapper.Map<Empleado>(model);

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

        public async Task<ResponseHelper> Update(EmpleadoBaseDto model)
        {
            var result = new ResponseHelper();

            try
            {
                var originalEntry = await _context.Empleados.SingleAsync(x => x.EmpleadoId == model.EmpleadoId);
                Mapper.Map(model, originalEntry);

                _context.Update(originalEntry);
                await _context.SaveChangesAsync();

                //_context.Entry(originalEntry).State = EntityState.Unchanged;
                // await _context.SaveChangesAsync();

                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }
    }


}
