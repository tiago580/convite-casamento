using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [HttpPost]
        public IActionResult Inserir([FromBody] EventoDTO evento)
        {
            try
            {
                eventoNegocio.Inserir(evento);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Alterar(int id,[FromBody] EventoDTO evento)
        {
            try
            {
                eventoNegocio.Alterar(id, evento);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                eventoNegocio.Remover(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Obter(int id)
        {
            try
            {
                var obj = eventoNegocio.Obter(id);
                return Ok(obj);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
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
        [HttpGet("{id}/convidados")]
        public IActionResult FiltrarConvidados(int id, [FromQuery] string nome = null)
        {
            try
            {
                var lista = eventoNegocio.FiltrarConvidados(id, nome);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        
    }
}