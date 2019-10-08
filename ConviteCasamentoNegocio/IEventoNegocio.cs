using ConviteCasamentoDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoNegocio
{
    public interface IEventoNegocio: INegocioBase<EventoDTO>
    {
        IEnumerable<EventoDTO> Consultar(string nome = null, DateTime? dataInicial = null, DateTime? dataFinal = null);
        IEnumerable<ConvidadoDTO> FiltrarConvidados(int idEvento, string nomeConvidado = null);
    }
}
