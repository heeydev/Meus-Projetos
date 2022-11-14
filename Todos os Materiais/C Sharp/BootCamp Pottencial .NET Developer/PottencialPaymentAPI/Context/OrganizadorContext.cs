using Microsoft.EntityFrameworkCore;
using PottencialPaymentAPI.Models;

namespace PottencialPaymentAPI.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
            
        }

        public DbSet<Registro> Registros { get; set; }
        public DbSet<Vendedor> Cadastros { get; set; }
    }
}