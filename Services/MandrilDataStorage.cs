using API_Ejemplo2.Models;

namespace API_Ejemplo2.Services
{
    //Base de datos en memoria
    //Simula una base de datos para almacenar los mandriles y sus habilidades
    public class MandrilDataStorage
    {

        public List<Mandril> ListaMandriles { get; set; }

        // Patrón Singleton: Permite que solo haya una instancia de MandrilDataStorage en toda la aplicación
        public static MandrilDataStorage Current { get; } = new MandrilDataStorage();


        public MandrilDataStorage()
        {
            ListaMandriles = new List<Mandril>(){

            new Mandril()
            {
                Id = 1,
                Nombre = "Albino",
                Apellido = "Rodrigez",
                Habilidades =  new List<Habilidad>()
                {
                    new Habilidad(){
                        Id = 1,
                        Nombre = "Saltar",
                        Potencia = Habilidad.EPotencia.MODERADO
                    },
                    new Habilidad(){
                        Id = 2,
                        Nombre = "Caminar",
                        Potencia = Habilidad.EPotencia.INTENSO
                    },
                    new Habilidad(){
                        Id = 3,
                        Nombre = "Gritar",
                        Potencia = Habilidad.EPotencia.EXTREMO
                    }
                }
            },
            new Mandril()
            {
                Id = 2,
                Nombre = "Mini",
                Apellido = "Fernandez",
                Habilidades = new List<Habilidad>()
                {
                    new Habilidad(){
                        Id = 1,
                        Nombre = "Saltar",
                        Potencia = Habilidad.EPotencia.MODERADO
                    },
                    new Habilidad(){
                        Id = 2,
                        Nombre = "Caminar",
                        Potencia = Habilidad.EPotencia.INTENSO
                    },
                    new Habilidad(){
                        Id = 3,
                        Nombre = "Gritar",
                        Potencia = Habilidad.EPotencia.EXTREMO
                    }
                }
            },
            new Mandril()
            {
                Id = 3,
                Nombre = "MegaMandril",
                Apellido = "Legrand",
                Habilidades = new List<Habilidad>()
                {
                    new Habilidad(){
                        Id = 1,
                        Nombre = "Nadar",
                        Potencia = Habilidad.EPotencia.INTENSO
                    },
                    new Habilidad(){
                        Id = 2,
                        Nombre = "Correr",
                        Potencia = Habilidad.EPotencia.EXTREMO
                    },
                    new Habilidad(){
                        Id = 3,
                        Nombre = "Vomitar",
                        Potencia = Habilidad.EPotencia.FUERTE
                    }
                }
            }

            };
        }
    }
}