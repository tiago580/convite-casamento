using ConviteCasamentoDominio;
using ConviteCasamentoDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoNegocio
{
    public interface IConvidadoNegocio: INegocioBase<ConvidadoDTO>
    {
        void AtualizarStatus(int id, StatusDTO status);

        IEnumerable<ConvidadoDTO> Consultar(String nome, StatusDTO status);
    }
}
