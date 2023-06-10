using Microsoft.EntityFrameworkCore;
using NIPSearchWebApi.Models;

namespace NIPSearchApp.Data.DbContexts
{
    public class EnterpreneurDbContext : DbContext
    {
        public EnterpreneurDbContext()
        {
        }

        public EnterpreneurDbContext(DbContextOptions<EnterpreneurDbContext> options)
        : base(options)
        {
        }

        public DbSet<EnterpreneurModel> Enterpreneurs { get; set; }
    }
}