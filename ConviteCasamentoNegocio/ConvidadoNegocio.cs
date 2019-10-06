using AutoMapper;
using ConviteCasamentoDominio;
using ConviteCasamentoDTO;
using ConviteCasamentoRepositorio;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq.Expressions;

namespace ConviteCasamentoNegocio
{
    public class ConvidadoNegocio : NegocioBase<ConvidadoDTO, Convidado>, IConvidadoNegocio
    {
        public ConvidadoNegocio(IConvidadoRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        public void AtualizarStatus(int id, StatusDTO status)
        {
            var rep = repositorio as IConvidadoRepositorio;
            rep.AtualizarStatus(id, mapper.Map<Status>(status));
        }

        public IEnumerable<ConvidadoDTO> Consultar(string nome, StatusDTO status)
        {
            var _status = mapper.Map<Status>(status);
            Expression<Func<Convidado, bool>> _where = obj => obj.Nome.Contains(nome) && 
                (status == StatusDTO.TODOS || obj.Status == _status);

            var _list = repositorio.Consultar(_where);
            if (_list != null)
            {
                return mapper.Map<IEnumerable<ConvidadoDTO>>(_list);
            }
            return Enumerable.Empty<ConvidadoDTO>();
        }
    }
}
