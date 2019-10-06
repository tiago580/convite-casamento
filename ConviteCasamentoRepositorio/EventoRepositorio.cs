using ConviteCasamentoDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoRepositorio
{
    public class EventoRepositorio : RepositorioBase<Evento>, IEventoRepositorio
    {
        public EventoRepositorio(DbContext context) : base(context)
        {
        }
    }
}
