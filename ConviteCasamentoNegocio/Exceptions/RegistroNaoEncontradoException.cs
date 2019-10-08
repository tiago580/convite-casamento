using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoNegocio.Exceptions
{
    public class RegistroNaoEncontradoException: KeyNotFoundException
    {
        public override string Message => "Registro não encontrado.";
    }
}
