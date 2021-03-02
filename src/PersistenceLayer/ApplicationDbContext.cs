using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommonLayer.Extensions;

namespace PersistenceLayer
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor
            ) : base(options)
        {
            //entity framework mas rapido 
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = true;
            this.httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbQuery<Usuario> Usuarios { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsuarioRole> UsuariosRoles { get; set; }
        public DbSet<UsuarioAcceso> UsuariosAcceso { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UsuarioRole>().HasKey(a => new { a.UsuarioId, a.RoleId });
            builder.Entity<Empleado>().HasKey(a => new { a.EmpleadoId });
            builder.Entity<Puesto>().HasKey(a => new { a.PuestoId });
            builder.Entity<Departamento>().HasKey(a => new { a.DepartamentoId });

            ModelConfig(builder);
        }
        private void ModelConfig(ModelBuilder modelBuilder)
        {

        }

        

    }
}
