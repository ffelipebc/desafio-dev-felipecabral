using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioByCoders.Model
{
    [Table("Lojas")]
    public class Loja
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Dono { get; set; }
        public ICollection<Transacao> Transacoes { get; set; }
    }
}
