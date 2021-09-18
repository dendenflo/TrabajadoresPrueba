using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabajadoresPrueba.Entidades
{
    public class Distrito
    {
        [Key]
        public int Id { get; set; }

        public int IdProvincia { get; set; }
        public string NombreDistrito { get; set; }
    }
}