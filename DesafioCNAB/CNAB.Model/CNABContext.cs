using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioByCoders.Model
{
    public class CNABContext : DbContext
    {
        public CNABContext(DbContextOptions<CNABContext> options) : base(options) { }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    }
}
