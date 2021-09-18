using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabajadoresPrueba.Entidades
{
    public class Trabajadores
    {
        [Key]
        public int Id { get; set; }

        public string TipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }
    }
}