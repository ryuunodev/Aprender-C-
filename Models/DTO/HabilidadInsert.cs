using System.ComponentModel.DataAnnotations;
using static API_Ejemplo2.Models.Habilidad;

namespace API_Ejemplo2.Models.DTO
{
    public class HabilidadInsert
    {
        [Required()]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required()]
        public EPotencia Potencia { get; set; }

    }
}
