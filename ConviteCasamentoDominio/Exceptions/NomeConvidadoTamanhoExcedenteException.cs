using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoDominio.Exceptions
{
    public class NomeConvidadoTamanhoExcedenteException : Exception
    {
        public override string Message => "Nome do convidado excedeu o limite de caracteres.";
    }
}
