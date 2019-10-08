using AutoMapper;
using ConviteCasamentoDominio;
using ConviteCasamentoDTO;
using ConviteCasamentoNegocio.Exceptions;
using ConviteCasamentoRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ConviteCasamentoNegocio
{
    public class EventoNegocio : NegocioBase<EventoDTO, Evento>, IEventoNegocio
    {
        private IConvidadoRepositorio convidadoRepositorio;
        public EventoNegocio(IEventoRepositorio repositorio, IConvidadoRepositorio convidadoRepositorio, IMapper mapper) : base(repositorio, mapper)
        {
            this.convidadoRepositorio = convidadoRepositorio;
        }

        public IEnumerable<EventoDTO> Consultar(string nome = null, DateTime? dataInicial = null, DateTime? dataFinal = null)
        {
            Expression<Func<Evento, bool>> _where = obj =>
               (string.IsNullOrEmpty(nome) || obj.Nome.Contains(nome)) &&
               (dataInicial == null || obj.Data >= dataInicial) &&
               (dataFinal == null || obj.Data <= dataFinal);

            var _list = repositorio.Consultar(_where);
            if (_list != null)
            {
                return mapper.Map<IEnumerable<EventoDTO>>(_list);
            }
            return Enumerable.Empty<EventoDTO>();
        }

        public IEnumerable<ConvidadoDTO> FiltrarConvidados(int idEvento, string nomeConvidado = null)
        {
            Expression<Func<Convidado, bool>> _where = obj =>
                obj.EventoId == idEvento &&
               (string.IsNullOrEmpty(nomeConvidado) || obj.Nome.Contains(nomeConvidado));

            var _list = convidadoRepositorio.Consultar(_where);
            if (_list != null)
            {
                return mapper.Map<IEnumerable<ConvidadoDTO>>(_list);
            }
            return Enumerable.Empty<ConvidadoDTO>();
        }

        protected override Evento ValidarObjeto(EventoDTO obj)
        {
            var evento = base.ValidarObjeto(obj);
            validarConvidados(evento.Convidados);
            return evento;
        }

        private void validarConvidados(IEnumerable<Convidado> convidados)
        {
            if (convidados != null)
            {
                foreach (var convidado in convidados)
                {
                    if (convidado == null)
                    {
                        throw new ParametroNuloException("Convidado inválido.");
                    }

                    convidado.Validar();
                }
            }
        }

    }
}
