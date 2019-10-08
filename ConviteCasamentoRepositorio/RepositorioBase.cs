using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConviteCasamentoDominio;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConviteCasamentoRepositorio
{
    public abstract class RepositorioBase<T>  : IRepositorioBase<T> where T : ADominio
    {
        protected DbContext _context;

        public RepositorioBase(DbContext context)
        {
            _context = context;
        }
        public virtual void Alterar(T obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }

        public IEnumerable<T> Consultar(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        public void Inserir(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public virtual T Obter(int id, bool noTrancking = true)
        {
            bool _where(T obj) => obj.Id == id;
            if (noTrancking)
            {
                return _context.Set<T>().AsNoTracking().Where(_where).FirstOrDefault();
            }
            return _context.Set<T>().Where(_where).FirstOrDefault();
        }

        public void Remover(int id)
        {
            T obj = Obter(id, false);
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
}
