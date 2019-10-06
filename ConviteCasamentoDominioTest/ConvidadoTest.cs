using ConviteCasamentoDominio;
using ConviteCasamentoDominio.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoTests
{
    [TestClass]
    public class ConvidadoTest
    {

        [TestMethod]
        [ExpectedException(typeof(NomeConvidadoNaoInformadoException))]
        public void NomeConvidadoNaoInformadoTest()
        {
            var convidado = new Convidado();
            convidado.Validar();

        }
        [TestMethod]
        [ExpectedException(typeof(NomeConvidadoTamanhoExcedenteException))]
        public void NomeConvidadoNaoTamanhoExcedenteTest()
        {
            var convidado = new Convidado()
            {
                Nome = "Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha Tiago Vieira da Rocha"
            };
            convidado.Validar();

        }
    }
}
