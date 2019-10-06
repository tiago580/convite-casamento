using ConviteCasamentoDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoNegocio
{
    public interface IEventoNegocio: INegocioBase<EventoDTO>
    {
        IEnumerable<EventoDTO> Consultar(String nome = null, DateTime? dataInicial = null, DateTime? dataFinal = null);
    }
}
