using Application.Interfaces.Services;
using ImdbIoasys;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Application.Services.Tests
{
    [TestClass()]
    public class FilmeServiceTests
    {
        private readonly IServiceProvider _services =
        Program.CreateHostBuilder(new string[] { }).Build().Services;

        [TestMethod()]
        public void QuandoClassificacaoIncorretaDeveRetornarFalse()
        {
            var filmeService = _services.GetRequiredService<IFilmeService>();
            Assert.AreEqual(expected: false, actual: filmeService.ValidarClassificacao(5));
        }

        [TestMethod()]
        public void QuandoClassificacaoCorretaDeveRetornarTrue()
        {
            var filmeService = _services.GetRequiredService<IFilmeService>();
            Assert.AreEqual(expected: true, actual: filmeService.ValidarClassificacao(3));
        }
    }
}