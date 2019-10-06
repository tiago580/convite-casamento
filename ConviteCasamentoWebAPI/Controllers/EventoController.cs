using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConviteCasamentoDTO;
using ConviteCasamentoNegocio;
using ConviteCasamentoWebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ConviteCasamentoWebAPI.Controllers
{
    [ApiController]
    [Route("api/evento")]
    public class EventoController : Controller
    {
        private IEventoNegocio eventoNegocio;
        public EventoController(IEventoNegocio eventoNegocio)
        {
            this.eventoNegocio = eventoNegocio;
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] string nome = null, [FromQuery] string dataInicial = null, [FromQuery] string dataFinal = null)
        {
            DateTime? dtInicial = null;
            DateTime? dtFinal = null;
            try
            {
                if (dataInicial != null)
                {
                    if (!DateTime.TryParse(dataInicial, out DateTime dtIni))
                    {
                        throw new DataInvalidaException("Data Inicial inválida.");
                    }
                    dtInicial = dtIni;
                }

                if (dataFinal != null)
                {
                    if (!DateTime.TryParse(dataFinal, out DateTime dtFin))
                    {
                        throw new DataInvalidaException("Data Final inválida.");
                    }
                    dtFinal = dtFin;
                }
                var lista = eventoNegocio.Consultar(nome, dtInicial, dtFinal);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        
    }
}