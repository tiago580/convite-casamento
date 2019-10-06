using AutoMapper;
using ConviteCasamentoDominio;
using ConviteCasamentoDTO;
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
        public EventoNegocio(IEventoRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        public IEnumerable<EventoDTO> Consultar(string nome = null, DateTime? dataInicial = null, DateTime? dataFinal = null)
        {
            Expression<Func<Evento, bool>>  _where = obj => (nome == null || obj.Nome.Contains(nome)) &&
                (dataInicial == null || obj.Data.CompareTo(dataInicial) >= 0) &&
                (dataFinal == null || obj.Data.CompareTo(dataFinal) <= 0);

            var _list = repositorio.Consultar(_where);
            if (_list != null)
            {
                return mapper.Map<IEnumerable<EventoDTO>>(_list);
            }
            return Enumerable.Empty<EventoDTO>();
        }

    }
}
