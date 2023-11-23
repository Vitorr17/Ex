using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMaquina.Models;

namespace WebMaquina.Data
{
    public class BDContext : DbContext
    {
        public BDContext (DbContextOptions<BDContext> options)
            : base(options)
        {
        }

        public DbSet<WebMaquina.Models.CadCliente> CadCliente { get; set; } = default!;

        public DbSet<WebMaquina.Models.CadMaquina> CadMaquina { get; set; } = default!;

        public DbSet<WebMaquina.Models.Inventario> Inventario { get; set; } = default!;
    }
}
