using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace CNAB.Frontend.Pages
{
    public class UploadModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _environment;

        public UploadModel(HttpClient httpClient, IWebHostEnvironment environment)
        {
            _httpClient = httpClient;
            _environment = environment;
        }

        [BindProperty]
        public IFormFile? Arquivo { get; set; }

        public string? Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Arquivo == null || Arquivo.Length == 0)
            {
                Message = "Por favor, selecione um arquivo.";
                return Page();
            }

            using var fileStream = Arquivo.OpenReadStream();
            using var content = new MultipartFormDataContent();
            using var fileContent = new StreamContent(fileStream);

            fileContent.Headers.ContentType = new MediaTypeHeaderValue(Arquivo.ContentType);
            content.Add(fileContent, "file", Arquivo.FileName);

            var response = await _httpClient.PostAsync("https://localhost:7215/CNAB/upload", content);

            if (response.IsSuccessStatusCode)
            {
                Message = "Arquivo enviado e processado com sucesso!";
            }
            else
            {
                Message = "Erro ao enviar o arquivo para a API.";
            }

            return Page();
        }
    }
}
