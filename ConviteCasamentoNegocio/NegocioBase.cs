using AutoMapper;
using ConviteCasamentoDominio;
using ConviteCasamentoDTO;
using ConviteCasamentoNegocio.Exceptions;
using ConviteCasamentoRepositorio;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace ConviteCasamentoNegocio
{
    public abstract class NegocioBase<T, D> : INegocioBase<T> where T : ADTO where D: ADominio
    {
        protected IRepositorioBase<D> repositorio;
        protected IMapper mapper;
        public NegocioBase(IRepositorioBase<D> repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        public virtual void Alterar(int id, T obj)
        {
            if (!ExisteRegistro(id))
            {
                throw new RegistroNaoEncontradoException();
            }
            var _obj = ValidarObjeto(obj);
            _obj.Id = id;
            repositorio.Alterar(_obj);
        }

        public bool ExisteRegistro(int id)
        {
            return repositorio.Obter(id) != null;
        }

        public void Inserir(T obj)
        {
            var _obj = ValidarObjeto(obj);
            repositorio.Inserir(_obj);
        }

        public T Obter(int id)
        {
            var _obj = repositorio.Obter(id);
            if (_obj != null)
            {
                var obj = mapper.Map<T>(_obj);
                return obj;
            }

            throw new RegistroNaoEncontradoException();
        }

        public void Remover(int id)
        {
            if (!ExisteRegistro(id))
            {
                throw new RegistroNaoEncontradoException();
            }
            repositorio.Remover(id);
        }

        protected virtual D ValidarObjeto(T obj)
        {
            if (obj == null)
            {
                throw new ParametroNuloException();
            }

            var _obj = mapper.Map<D>(obj);
            _obj.Validar();
            return _obj;
        }

    }
}
