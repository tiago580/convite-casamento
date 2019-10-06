using AutoMapper;
using ConviteCasamentoDominio;
using ConviteCasamentoDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoNegocio
{
    public class ConviteCasamentoNegocioMapperProfile: Profile
    {
        public ConviteCasamentoNegocioMapperProfile()
        {
            CreateMap<EventoDTO, Evento>();
            CreateMap<Evento, EventoDTO>();

            CreateMap<ConvidadoDTO, Convidado>();
            CreateMap<Convidado, ConvidadoDTO>();

            CreateMap<StatusDTO, Status>();
            CreateMap<Status, StatusDTO>();
            
        }
    }
}
