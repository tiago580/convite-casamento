using ConviteCasamentoDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoServico
{
    public interface IServicoBase<T> where T: ADTO
    {
        void Inserir(T obj);
        void Alterar(T obj);
        void Remover(int id);
        T Obter(int id, bool noTrancking = true);

    }
}
