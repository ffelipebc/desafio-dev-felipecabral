using CNAB.Frontend.Pages;

namespace CNAB.Frontend.ViewModel
{
    public class TransacaoViewModel
    {
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string CPF { get; set; }
        public string Cartao { get; set; }
    }

}
