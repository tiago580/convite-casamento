using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConviteCasamentoWebAPI.Exceptions
{
    public class DataInvalidaException: Exception
    {
        public DataInvalidaException(): base()
        {

        }

        public DataInvalidaException(string msg): base(msg)
        {

        }
    }
}
