using DesafioByCoders.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace DesafioByCoders.Service
{
    public class CNABService
    {
        private readonly CNABContext _context;

        public CNABService(CNABContext context)
        {
            _context = context;
        }

        public async Task ProcessarArquivoCNABAsync(string filePath)
        {
            var linhas = await File.ReadAllLinesAsync(filePath);
            foreach (var linha in linhas)
            {
                var tipo = int.Parse(linha.Substring(0, 1));
                var data = DateTime.ParseExact(linha.Substring(1, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
                var valor = decimal.Parse(linha.Substring(9, 10)) / 100;
                var cpf = linha.Substring(19, 11);
                var cartao = linha.Substring(30, 12);
                var donoLoja = linha.Substring(48, 14).Trim();
                var nomeLoja = linha.Substring(62, 18).Trim();

                var loja = _context.Lojas.FirstOrDefault(l => l.Nome == nomeLoja);
                if (loja == null)
                {
                    loja = new Loja { Nome = nomeLoja, Dono = donoLoja, Transacoes = new List<Transacao>() };
                    _context.Lojas.Add(loja);
                }

                var transacao = new Transacao
                {
                    Tipo = tipo,
                    Data = data,
                    Valor = valor,
                    CPF = cpf,
                    Cartao = cartao,
                    Loja = loja
                };

                _context.Transacoes.Add(transacao);
            }
            await _context.SaveChangesAsync();
        }
    }
}
