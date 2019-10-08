using ConviteCasamentoDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoRepositorio
{
    public class EventoRepositorio : RepositorioBase<Evento>, IEventoRepositorio
    {
        public EventoRepositorio(DbContext context) : base(context)
        {
        }

        public override void Alterar(Evento obj)
        {
            var context = _context as ConviteCasamentoContext;

            context.Convidados.RemoveRange(context.Convidados.Where(c => c.EventoId == obj.Id));
            context.Update(obj);
            context.SaveChanges();
            
        }

        public override Evento Obter(int id, bool noTrancking = true)
        {
            var context = _context as ConviteCasamentoContext;
            bool _where(Evento obj) => obj.Id == id;
            if (noTrancking)
            {
                return context.Eventos.Include(e => e.Convidados).AsNoTracking().Where(_where).FirstOrDefault();
            }
            return context.Eventos.Include(e => e.Convidados).Where(_where).FirstOrDefault();
        }

    }
}
