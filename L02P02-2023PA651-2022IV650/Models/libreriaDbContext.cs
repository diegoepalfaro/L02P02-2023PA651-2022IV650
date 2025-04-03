using Microsoft.EntityFrameworkCore;
namespace L02P02_2023PA651_2022IV650.Models
{
    public class libreriaDbContext : DbContext
    {
        public libreriaDbContext(DbContextOptions options) : base(options) { 
        
        }
    }
}
