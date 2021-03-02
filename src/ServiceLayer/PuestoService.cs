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
    public interface IPuestoService
    {
        Task<IEnumerable<PuestoDto>> GetPuestos();
    }
    public class PuestoService: IPuestoService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public PuestoService(
            ApplicationDbContext context,
            ILogger<PuestoService> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task<IEnumerable<PuestoDto>> GetPuestos()
        {
            var result = new List<PuestoDto>();

            try
            {
                var records = await _context.Puestos.ToListAsync();
                result = Mapper.Map<List<PuestoDto>>(records);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }
    }


}
