using DesafioByCoders.Model;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB.Model
{
    public class CNABContextFactory : IDesignTimeDbContextFactory<CNABContext>
    {
        public CNABContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CNABContext>();
            var connectionString = "Server=localhost\\SQLEXPRESS;Database=Desafio_CNAB;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
            return new CNABContext(optionsBuilder.Options);
        }
    }
}
