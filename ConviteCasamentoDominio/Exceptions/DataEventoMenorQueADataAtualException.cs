using System;
using System.Collections.Generic;
using System.Text;

namespace ConviteCasamentoDominio.Exceptions
{
    public class DataEventoMenorQueADataAtualException: Exception
    {
        public override string Message => "Data do evento menor que a data atual.";
    }
}
