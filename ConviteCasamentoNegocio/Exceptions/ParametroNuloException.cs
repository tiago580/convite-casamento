using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoNegocio.Exceptions
{
    public class ParametroNuloException: Exception
    {
        public ParametroNuloException(): base()
        {

        }
        public ParametroNuloException(string msg): base(msg)
        {

        }
        public override string Message => $"Parâmetro obrigatório não informado. {base.Message}";
    }
}
