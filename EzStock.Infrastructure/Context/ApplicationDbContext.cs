using EzStock.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EzStock.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        DbSet<Product> Products { get; set; }
    }
}
