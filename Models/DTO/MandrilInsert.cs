using System.ComponentModel.DataAnnotations;

namespace API_Ejemplo2.Models.DTO
{
    public class MandrilInsert
    {
        [Required()]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required()]
        [MaxLength(50)]
        public string Apellido { get; set; } = string.Empty;

        //public List<Habilidad>? Habilidades { get; set; }
    }
}
