using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoDominio.Exceptions
{
    public class NomeConvidadoNaoInformadoException: Exception
    {
        public override string Message => "Nome do convidado não informado."; 
    }
}
