using DesafioByCoders.Model;
using DesafioByCoders.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CNAB.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CNABController : ControllerBase
{
    private readonly CNABService _cnabService;
    private readonly CNABContext _context;

    public CNABController(CNABService cnabService, CNABContext context)
    {
        _cnabService = cnabService;
        _context = context;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Nenhum arquivo enviado.");

        var filePath = Path.GetTempFileName();
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        await _cnabService.ProcessarArquivoCNABAsync(filePath);
        return Ok("Arquivo processado com sucesso.");
    }

    [HttpGet("lojas")]
    public async Task<IActionResult> GetLojas()
    {
        var lojas = await _context.Lojas.Include(l => l.Transacoes).ToListAsync();
        var resultado = lojas.Select(l => new
        {
            l.Nome,
            l.Dono,
            SaldoTotal = l.Transacoes.Sum(t => t.Valor),
            Transacoes = l.Transacoes.Select(t => new
            {
                t.Tipo,
                t.Data,
                t.Valor,
                t.CPF,
                t.Cartao
            })
        });
        return Ok(resultado);
    }
}
