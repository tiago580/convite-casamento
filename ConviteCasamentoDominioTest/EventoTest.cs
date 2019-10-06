using ConviteCasamentoDominio;
using ConviteCasamentoDominio.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConviteCasamentoTests
{
    [TestClass]
    public class EventoTest
    {
        [TestMethod]
        [ExpectedException(typeof(NomeEventoNaoInformadoException))]
        public void ValidarEventoNomeTest()
        {
            var evento = new Evento();
            evento.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(NomeEventoTamanhoExcedenteException))]
        public void ValidarEventoNomeTamanhoExcedenteTest()
        {
            var evento = new Evento()
            { 
                Nome = "Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1Casamento 1"
            };
            evento.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DataEventoMenorQueADataAtualException))]
        public void ValidarEventoDataTest()
        {
            var evento = new Evento()
            {
                Nome = "Casamento 1",
                Data = DateTime.Today.AddHours(-1)
            };
            evento.Validar();
        }

    }
}
