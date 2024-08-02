using Microsoft.EntityFrameworkCore;

namespace CRUDModals.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }        
    }
}