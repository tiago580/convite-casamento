using ConviteCasamentoDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoRepositorio
{
    public class ConvidadoRepositorio : RepositorioBase<Convidado>, IConvidadoRepositorio
    {
        public ConvidadoRepositorio(DbContext context) : base(context)
        {
        }

        public void AtualizarStatus(int id, Status status)
        {
            var obj = Obter(id, false);
            obj.Status = status;
        }
    }
}
