using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabajadoresPrueba.Entidades
{
    public class PR_TRABA
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tipo Documento")]
        public string TipoDocumento { get; set; }

        [Display(Name = "Nro Documento")]
        public string NroDocumento { get; set; }

        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Display(Name = "Departamento")]
        public string NombreDepartamento { get; set; }

        [Display(Name = "Provincia")]
        public string NombreProvincia { get; set; }

        [Display(Name = "Distrito")]
        public string NombreDistrito { get; set; }
    }
}