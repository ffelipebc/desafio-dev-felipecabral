using CNAB.Frontend.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace CNAB.Frontend.Pages
{
    public class TransacoesModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public TransacoesModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<LojaViewModel> Lojas { get; set; }

        public async Task OnGetAsync()
        {
            Lojas = await _httpClient.GetFromJsonAsync<IEnumerable<LojaViewModel>>("https://localhost:7215/CNAB/lojas");
        }
    }
}
