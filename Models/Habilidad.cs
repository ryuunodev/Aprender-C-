namespace API_Ejemplo2.Models {
    public class Habilidad
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public EPotencia Potencia { get; set; }


        public enum EPotencia
        {
            SUAVE,
            MODERADO,
            INTENSO,
            FUERTE,
            EXTREMO
        }
    }
}
