using ConviteCasamentoDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoRepositorio
{
    public interface IConvidadoRepositorio : IRepositorioBase<Convidado>
    {
        void AtualizarStatus(int id, Status status);
    }
}
