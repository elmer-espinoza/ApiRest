using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestDesktopClient.Models
{
    [Table (name: "ApiRest")]
    public class Employee
    {

        [Key]
        [Column(name: "Id")]
        public int Id { get; set; }
        [Required (ErrorMessage = "Ingrese el Nombre")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el DNI")]
        public string? DNI { get; set; }
        public short? Edad { get; set; }
        [Display(Name="Teléfono")]
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        [Display(Name = "Básico")]
        public decimal? Basico { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        [Required(ErrorMessage = "Ingrese el Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy hh:mm}")]
        public DateTime? Ingreso { get; set; }
        public bool? Activo { get; set; }
         

        /* Constructor 
        public Employee(int id, string nombre, string dni, short edad, string telefono, string correo, decimal basico, DateTime ingreso, bool activo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.DNI = dni;
            this.Edad = edad;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Basico = basico;
            this.Ingreso = ingreso;
            this.Activo = activo;
        }
        */

    }

}
