using ConviteCasamentoDominio.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConviteCasamentoDominio
{
    [Table("EVENTO")]
    public class Evento: ADominio
    {

        [Column("NOME")]
        public string Nome { get; set; }
        [Column("DATA")]
        public DateTime Data { get; set; }

        public ICollection<Convidado> Convidados { get; set; }

        public override void Validar()
        {
            ValidarNome();
            ValidarData();
        }



        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(Nome) || string.IsNullOrWhiteSpace(Nome))
            {
                throw new NomeEventoNaoInformadoException();
            }

            ValidarTamanhoNome();

        }
        private void ValidarTamanhoNome()
        {
            if (!string.IsNullOrEmpty(Nome) && Nome.Length > 255)
            {
                throw new NomeEventoTamanhoExcedenteException();
            }

        }
        private void ValidarData()
        {
            if (Data.CompareTo(DateTime.Now) < 1)
            {
                throw new DataEventoMenorQueADataAtualException();
            }
        }
    }
}
