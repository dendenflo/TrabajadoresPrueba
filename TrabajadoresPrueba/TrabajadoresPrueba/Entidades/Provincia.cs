using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabajadoresPrueba.Entidades
{
    public class Provincia
    {
        [Key]
        public int Id { get; set; }

        public int IdDepartamento { get; set; }
        public string NombreProvincia { get; set; }
    }
}