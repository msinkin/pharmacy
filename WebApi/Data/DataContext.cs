using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<DrugEntity> DrugEntities { get; set; }
        public DbSet<DrugManufacturerEntity> DrugManufacturerEntities { get; set; }
    }
}
