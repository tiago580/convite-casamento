using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConviteCasamentoDominio
{
    public abstract class ADominio
    {
        [Key]
        public int Id { get; set; }
        public abstract void Validar();
    }
}
