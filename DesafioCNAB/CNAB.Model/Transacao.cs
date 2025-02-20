using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioByCoders.Model
{
    [Table("Transacao")]
    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string CPF { get; set; }
        public string Cartao { get; set; }
        public int LojaId { get; set; }
        [ForeignKey("LojaId")]
        public Loja Loja { get; set; }
    }
}
