using Microsoft.EntityFrameworkCore;
namespace L02P02_2023PA651_2022IV650.Models
{
    public class libreriaDbContext : DbContext
    {
        public libreriaDbContext(DbContextOptions options) : base(options) { 
        
        }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<pedido_encabezado> pedido_encabezado { get; set; }

        public DbSet<Libros> Libros { get; set; }   

        public DbSet<pedido_detalle> pedido_detalle { get; set; }
    }
}
