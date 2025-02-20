using DesafioByCoders.Model;
using DesafioByCoders.Service;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB.Tests.UnitTests
{
    public class CNABServiceTests
    {
        private readonly CNABContext _context;
        private readonly CNABService _service;
        private readonly string _testFilePath;

        public CNABServiceTests()
        {
            // Criando um banco de dados em memória
            var options = new DbContextOptionsBuilder<CNABContext>()
                .UseInMemoryDatabase(databaseName: "CNABTestDB")
                .Options;

            _context = new CNABContext(options);
            _service = new CNABService(_context);

            // Criando um arquivo temporário de teste
            _testFilePath = Path.GetTempFileName();
            File.WriteAllLines(_testFilePath, new[]
            {
            "120220301000001234512345678901234CARTAO123      JOAO PEDRO      LOJA TESTE       "
        });
        }

        [Fact]
        public async Task ProcessarArquivoCNABAsync_DeveProcessarCorretamenteOArquivo()
        {
            // Act
            await _service.ProcessarArquivoCNABAsync(_testFilePath);

            // Assert
            var lojas = _context.Lojas.Include(l => l.Transacoes).ToList();
            lojas.Should().HaveCount(1);
            var loja = lojas.First();
            loja.Nome.Should().Be("LOJA TESTE");
            loja.Dono.Should().Be("JOAO PEDRO");
            loja.Transacoes.Should().HaveCount(1);

            var transacao = loja.Transacoes.First();
            transacao.Tipo.Should().Be(1);
            transacao.Valor.Should().Be(12345 / 100m);
            transacao.CPF.Should().Be("12345678901");
            transacao.Cartao.Should().Be("234CARTAO123");
            transacao.Data.Should().Be(new DateTime(2022, 03, 01));
        }
    }
}
