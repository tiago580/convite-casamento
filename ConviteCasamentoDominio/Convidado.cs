using ConviteCasamentoDominio.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConviteCasamentoDominio
{
    [Table("CONVIDADO")]
    public class Convidado: ADominio
    {

        [Column("NOME")]
        public string Nome { get; set; }
        [Column("STATUS")]
        public Status Status { get; set; }
        [Required]
        [Column("EVENTO_ID")]
        public int EventoId { get; set; }

        public Evento Evento { get; set; }
        public override void Validar()
        {
            ValidarNome();
        }

        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(Nome) || string.IsNullOrWhiteSpace(Nome))
            {
                throw new NomeConvidadoNaoInformadoException();
            }
            ValidarQuantidadeCaracteresNome();
        }
        private void ValidarQuantidadeCaracteresNome()
        {
            if (!string.IsNullOrEmpty(Nome) && Nome.Length > 255)
            {
                throw new NomeConvidadoTamanhoExcedenteException();
            }
        }
    }
}
