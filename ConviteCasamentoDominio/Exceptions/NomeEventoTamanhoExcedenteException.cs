using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoDominio.Exceptions
{
    public class NomeEventoTamanhoExcedenteException : Exception
    {
        public override string Message => "Nome do evento excedeu o limite de caracteres.";
    }
}
