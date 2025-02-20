using CNAB.Frontend.Pages;

namespace CNAB.Frontend.ViewModel
{
    public class LojaViewModel
    {
        public string Nome { get; set; }
        public string Dono { get; set; }
        public decimal SaldoTotal { get; set; }
        public List<TransacaoViewModel> Transacoes { get; set; }
    }

}
