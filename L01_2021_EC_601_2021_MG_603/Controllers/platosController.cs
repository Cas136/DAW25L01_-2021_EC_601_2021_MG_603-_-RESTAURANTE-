using MiApiRestaurante.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MiApiRestaurante.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        private static List<Plato> platos = new List<Plato>();

        [HttpGet]
        public ActionResult<IEnumerable<Plato>> GetPlatos() => platos;

        [HttpGet("{id}")]
        public ActionResult<Plato> GetPlato(int id)
        {
            var plato = platos.FirstOrDefault(p => p.Id == id);
            if (plato == null) return NotFound();
            return plato;
        }

        [HttpPost]
        public ActionResult<Plato> CreatePlato(Plato plato)
        {
            platos.Add(plato);
            return CreatedAtAction(nameof(GetPlato), new { id = plato.Id }, plato);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlato(int id, Plato plato)
        {
            var existing = platos.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();

            existing.Nombre = plato.Nombre;
            existing.Precio = plato.Precio;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlato(int id)
        {
            var plato = platos.FirstOrDefault(p => p.Id == id);
            if (plato == null) return NotFound();

            platos.Remove(plato);
            return NoContent();
        }

        [HttpGet("filtrarPorPrecio/{precio}")]
        public ActionResult<IEnumerable<Plato>> GetPlatosPorPrecio(decimal precio) =>
            platos.Where(p => p.Precio < precio).ToList();
    }
}
