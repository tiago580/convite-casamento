using ConviteCasamentoDTO;
using System;

namespace ConviteCasamentoServico
{
    public abstract class ServicoBase<T> : IServicoBase<T> where T : ADTO
    {
        public void Alterar(T obj)
        {
            throw new NotImplementedException();
        }

        public void Inserir(T obj)
        {
            throw new NotImplementedException();
        }

        public T Obter(int id, bool noTrancking = true)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
