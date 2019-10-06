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
    public class EventoNegocioTest
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
            var mock = new Mock<IEventoRepositorio>();
            var mockMapper = new Mock<IMapper>();
            var negocio = new EventoNegocio(mock.Object, mockMapper.Object);
            negocio.Inserir(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NomeEventoNaoInformadoException))]
        public void InserirNomeNaoInformadoTest()
        {
            var mock = new Mock<IEventoRepositorio>();
            var negocio = new EventoNegocio(mock.Object, mapper);
            negocio.Inserir(new EventoDTO());
        }
        [TestMethod]
        [ExpectedException(typeof(DataEventoMenorQueADataAtualException))]
        public void DataEventoMenorQueADataAtualTest()
        {
            var evento = new EventoDTO()
            {
                Nome = "Casamento 1",
                Data = DateTime.Today.AddHours(-1)
            };
            var mock = new Mock<IEventoRepositorio>();
            var negocio = new EventoNegocio(mock.Object, mapper);
            negocio.Inserir(evento);
        }

    }
}
