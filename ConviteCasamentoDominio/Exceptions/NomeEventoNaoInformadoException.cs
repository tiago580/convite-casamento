using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoDominio.Exceptions
{
    public class NomeEventoNaoInformadoException: Exception
    {
        public override string Message => "Nome do evento não informado."; 
    }
}
