using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiegoCorrea.Models
{
    public class DCorrea
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int NumHijos { get; set; }

        [AllowedValues]
        public double Salario { get; set; }

        public string Ciudad { get; set; }

        [Required]
        public bool Activo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int CarreraId { get; set; }

        [ForeignKey("CarreraId")]
        public Carrera? Carrera { get; set; }

    }
}
