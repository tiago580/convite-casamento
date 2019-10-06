using ConviteCasamentoDominio;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ConviteCasamentoRepositorio
{
    public interface IRepositorioBase<T>
    {
        void Inserir(T obj);
        void Alterar(T obj);
        void Remover(int id);
        IEnumerable<T> Consultar(Expression<Func<T, bool>> predicate);
        T Obter(int id, bool noTrancking = true);
    }
}
