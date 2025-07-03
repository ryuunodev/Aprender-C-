using API_Ejemplo2.Helpers;
using API_Ejemplo2.Models;
using API_Ejemplo2.Models.DTO;
using API_Ejemplo2.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Ejemplo2.Controllers
{

    [ApiController]
    [Route("api/mandril/{idMandril}/[controller]")]
    // api/habilidad/
    public class HabilidadController : ControllerBase
    {

        // Retorna todas las habilidades de un mandril especifico
        [HttpGet]
        public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int idMandril)
        {
            var mandril = MandrilDataStorage.Current.ListaMandriles.FirstOrDefault(m => m.Id == idMandril);
            if (mandril == null)
            {
                return NotFound(Mensajes.MandrilMensaje.NotFound);
            }


            return Ok(mandril.Habilidades);
        }

        // Retorna todas las habilidades de un mandril especifico
        [HttpGet("{idHabilidad}")]
        public ActionResult<Habilidad> GetHabilidad(int idMandril, int idHabilidad)
        {
            var mandril = MandrilDataStorage.Current.ListaMandriles.FirstOrDefault(m => m.Id == idMandril);

            if (mandril == null)
            {
                return NotFound(Mensajes.MandrilMensaje.NotFound);
            }

            var habilidad = mandril.Habilidades?.FirstOrDefault(h => h.Id == idHabilidad);

            if (habilidad == null)
            {
                return NotFound(Mensajes.HabilidadMensaje.NotFound);
            }

            return Ok(habilidad);
        }



        [HttpPost("{idHabilidad}")]
        public ActionResult<Habilidad> PostHabilidad(int idMandril, HabilidadInsert habilidadInsert)
        {
            var mandril = MandrilDataStorage.Current.ListaMandriles.FirstOrDefault(m => m.Id == idMandril);

            if (mandril == null)
            {
                return NotFound(Mensajes.MandrilMensaje.NotFound);
            }

            var habilidadMismoNombre = mandril.Habilidades?.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);

            if (habilidadMismoNombre != null)
            {
                return BadRequest(Mensajes.HabilidadMensaje.Duplicated);
            }

            // Maximo id de habilidad
            int maxHabilidad = 0;
            if (mandril.Habilidades != null && mandril.Habilidades.Any())
            {
                maxHabilidad = mandril.Habilidades.Max(h => h.Id);
            }

            if (mandril.Habilidades == null)
            {
                mandril.Habilidades = new List<Habilidad>();
            }
            
            var nuevaHabilidad = new Habilidad()
            {
                Id = maxHabilidad + 1,
                Nombre = habilidadInsert.Nombre,
                Potencia = habilidadInsert.Potencia
            };


            mandril.Habilidades.Add(nuevaHabilidad);

            return CreatedAtAction(nameof(GetHabilidad), new { id = mandril.Id, idHabilidad = nuevaHabilidad.Id }, nuevaHabilidad);
        }




        [HttpPut("{idHabilidad}")]
        public ActionResult<Habilidad> PutHabilidad(int idMandril, int idHabilidad, HabilidadInsert habilidadInsert)
        {
            //validaciones
            var mandril = MandrilDataStorage.Current.ListaMandriles.FirstOrDefault(m => m.Id == idMandril);

            if (mandril == null)
            {
                return NotFound(Mensajes.MandrilMensaje.NotFound);
            }

            var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Id == idHabilidad);

            if (habilidadExistente == null)
            {
                return NotFound(Mensajes.HabilidadMensaje.NotFound);
            }


            var habilidadMismoNombre = mandril.Habilidades?.FirstOrDefault(h => h.Id != idHabilidad && h.Nombre == habilidadInsert.Nombre);

            if (habilidadMismoNombre != null)
            {
                return BadRequest("Ya existe una habilidad con el mismo nombre.");
            }

            //asignacion
            habilidadExistente.Nombre = habilidadInsert.Nombre;
            habilidadExistente.Potencia = habilidadInsert.Potencia;

            return NoContent();
        }

        [HttpDelete("{idHabilidad}")]
        public ActionResult<Habilidad> DeleteHabilidad(int idMandril, int idHabilidad)
        {            
            //validaciones
            var mandril = MandrilDataStorage.Current.ListaMandriles.FirstOrDefault(m => m.Id == idMandril);

            if (mandril == null)
            {
                return NotFound(Mensajes.MandrilMensaje.NotFound);
            }

            var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Id == idHabilidad);

            if (habilidadExistente == null)
            {
                return NotFound(Mensajes.HabilidadMensaje.NotFound);
            }

            mandril.Habilidades?.Remove(habilidadExistente);

            return NoContent();
        }
            


    }
}