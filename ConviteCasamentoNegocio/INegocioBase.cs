using ConviteCasamentoDominio;
using ConviteCasamentoDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoNegocio
{
    public interface INegocioBase<T> where T: ADTO
    {
        void Inserir(T obj);
        void Alterar(int id, T obj);
        void Remover(int id);
        T Obter(int id);
        bool ExisteRegistro(int id);
    }
}
