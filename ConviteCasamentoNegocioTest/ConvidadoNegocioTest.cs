using ConviteCasamentoNegocio;
using ConviteCasamentoNegocio.Exceptions;
using ConviteCasamentoRepositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using AutoMapper;
using ConviteCasamentoDominio.Exceptions;
using ConviteCasamentoDominio;
using ConviteCasamentoDTO;
using System;

namespace ConviteCasamentoNegocioTest
{
    [TestClass]
    public class ConvidadoNegocioTest
    {
        IMapper mapper;
        [TestInitialize]
        public void SetUp()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "ConviteCasamentoNegocio"
                })
            );
            mapper = new Mapper(configuration);
        }

        [TestMethod]
        [ExpectedException(typeof(ParametroNuloException))]
        public void InserirParametroNuloTest()
        {
            var mock = new Mock<IConvidadoRepositorio>();
            var mockMapper = new Mock<IMapper>();
            var negocio = new ConvidadoNegocio(mock.Object, mockMapper.Object);
            negocio.Inserir(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NomeConvidadoNaoInformadoException))]
        public void InserirNomeNaoInformadoTest()
        {
            var mock = new Mock<IConvidadoRepositorio>();
            var negocio = new ConvidadoNegocio(mock.Object, mapper);
            negocio.Inserir(new ConvidadoDTO());
        }

    }
}
