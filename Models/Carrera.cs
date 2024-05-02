using System.ComponentModel.DataAnnotations;

namespace DiegoCorrea.Models
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreCarrera { get; set; }

        [AllowedValues]
        public string Campus { get; set; }

        public int NumeroSemestres { get; set; }

        public DCorrea DCorrea { get; set; }

    }
}
