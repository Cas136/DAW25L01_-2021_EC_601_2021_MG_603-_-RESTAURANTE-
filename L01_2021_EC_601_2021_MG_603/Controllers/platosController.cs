using L01_2021_EC_601_2021_MG_603.Models;
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
        private static List<platos> _platosList = new List<platos>();

        [HttpGet]
        public ActionResult<IEnumerable<platos>> GetPlatos() => _platosList;

        [HttpGet("{id}")]
        public ActionResult<platos> GetPlato(int id)
        {
            var plato = _platosList.FirstOrDefault(p => p.platoId == id);
            if (plato == null)
                return NotFound();
            return plato;
        }

        [HttpPost]
        public ActionResult<platos> CreatePlato(platos nuevoPlato)
        {
            _platosList.Add(nuevoPlato);
            return CreatedAtAction(nameof(GetPlato), new { id = nuevoPlato.platoId }, nuevoPlato);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlato(int id, platos platoActualizado)
        {
            var existing = _platosList.FirstOrDefault(p => p.platoId == id);
            if (existing == null)
                return NotFound();

            existing.nombrePlato = platoActualizado.nombrePlato;
            existing.precio = platoActualizado.precio;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlato(int id)
        {
            var plato = _platosList.FirstOrDefault(p => p.platoId == id);
            if (plato == null)
                return NotFound();

            _platosList.Remove(plato);
            return NoContent();
        }

        [HttpGet("filtrarPorPrecio/{precio}")]
        public ActionResult<IEnumerable<platos>> GetPlatosPorPrecio(decimal precio) =>
            _platosList.Where(p => p.precio < precio).ToList();
    }
}
