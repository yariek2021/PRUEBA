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
    public interface IDepartamentoService
    {
        Task<IEnumerable<DepartamentoDto>> GetDepartamentos();
    }
    public class DepartamentoService: IDepartamentoService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public DepartamentoService(
            ApplicationDbContext context,
            ILogger<DepartamentoService> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task<IEnumerable<DepartamentoDto>> GetDepartamentos()
        {
            var result = new List<DepartamentoDto>();

            try
            {
                var records = await _context.Departamentos.ToListAsync();
                result = Mapper.Map<List<DepartamentoDto>>(records);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }
    }


}
