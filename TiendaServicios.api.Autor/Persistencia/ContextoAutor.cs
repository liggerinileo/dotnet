using Microsoft.EntityFrameworkCore;
using TiendaServicios.api.Autor.Modelo;

namespace TiendaServicios.api.Autor.Persistencia
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options) { }
        
        public DbSet<AutorLibro> AutorLibro { get; set; }

        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}
