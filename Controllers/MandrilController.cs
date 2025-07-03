using API_Ejemplo2.Helpers;
using API_Ejemplo2.Models;
using API_Ejemplo2.Models.DTO;
using API_Ejemplo2.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Ejemplo2.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    //El nombre verdadero es api/mandril
    public class MandrilController : ControllerBase
    {
        //esto va a ser el controlador
        //ActionResult<T> es como mi ResponseEntity<T> en Springboot

        [HttpGet]
        public ActionResult<IEnumerable<Mandril>> GetMandriles()
        {
            return Ok(MandrilDataStorage.Current.ListaMandriles);
        }


        [HttpGet("{id}")]
        public ActionResult<Mandril> GetMandrilById(int id)
        {
            var mandril = MandrilDataStorage.Current.ListaMandriles.FirstOrDefault(m => m.Id == id);
            if (mandril == null)
            {
                return NotFound(Mensajes.MandrilMensaje.NotFound);
            }
            return Ok(mandril);
        }


        // POST api/mandril
        [HttpPost]
        public ActionResult<Mandril> CreateMandril(MandrilInsert mandrilInsert)
        {
            // creamos el id del nuevo mandril
            var maxId = MandrilDataStorage.Current.ListaMandriles.Max(m => m.Id);
            // Creamos al nuevo mandril
            var mandrilNuevo = new Mandril
            {
                Id = maxId + 1,
                Nombre = mandrilInsert.Nombre,
                Apellido = mandrilInsert.Apellido,
                Habilidades = new List<Habilidad>() // Inicializamos la lista de habilidades
            };

            MandrilDataStorage.Current.ListaMandriles.Add(mandrilNuevo);

            return CreatedAtAction(nameof(GetMandrilById), new { id = mandrilNuevo.Id }, mandrilNuevo);
        }

        // PUT api/mandril/{id}
        [HttpPut("{id}")]
        public ActionResult<Mandril> UpdateMandril([FromRoute] int id, [FromBody] MandrilInsert mandrilInsert)
        {
            var mandril = MandrilDataStorage.Current.ListaMandriles.FirstOrDefault(m => m.Id == id);

            if (mandril == null)
            {
                return NotFound(Mensajes.MandrilMensaje.NotFound);
            }

            mandril.Nombre = mandrilInsert.Nombre;
            mandril.Apellido = mandrilInsert.Apellido;

            return NoContent();
        }

        // DELETE api/mandril/{id}
        [HttpDelete("{id}")]
        public ActionResult<Mandril> DeleteMandril(int id)
        {
            var mandril = MandrilDataStorage.Current.ListaMandriles.Find(m => m.Id == id);

            if (mandril == null)
            {
                return NotFound(Mensajes.MandrilMensaje.NotFound);
            }

            MandrilDataStorage.Current.ListaMandriles.Remove(mandril);

            return NoContent();


        }
    }
}