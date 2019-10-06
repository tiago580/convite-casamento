using ConviteCasamentoRepositorio;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ConviteCasamentoContext())
            {
                // Read
                Console.WriteLine("Querying for a blog");
                var evento = context.Eventos
                    .OrderBy(b => b.GetId())
                    .FirstOrDefault();
            }
        }
    }
}
