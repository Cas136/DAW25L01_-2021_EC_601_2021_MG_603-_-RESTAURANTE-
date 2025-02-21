using MiApiRestaurante.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MiApiRestaurante.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class platosController : ControllerBase
    {
        private static List<platos> platos = new List<platos>();

        [HttpGet]
        public ActionResult<IEnumerable<Plato>> Getplatos() => platos;

        [HttpGet("{id}")]
        public ActionResult<platos> Getplatos(int id)
        {
            var plato = platos.FirstOrDefault(p => p.Id == id);
            if (platos == null) return NotFound();
            return platos;
        }

        [HttpPost]
        public ActionResult<platos> Createplatos(platos platos)
        {
            platos.Add(platos);
            return CreatedAtAction(nameof(Getplatos), new { id = platos.Id }, platos);
        }

        [HttpPut("{id}")]
        public IActionResult Updateplatos(int id, platos platos)
        {
            var existing = platos.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();

            existing.Nombre = platos.Nombre;
            existing.Precio = platos.Precio;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deleteplatos(int id)
        {
            var plato = platos.FirstOrDefault(p => p.Id == id);
            if (platos == null) return NotFound();

            platos.Remove(platos);
            return NoContent();
        }

        [HttpGet("filtrarPorPrecio/{precio}")]
        public ActionResult<IEnumerable<platos>> GetplatosPorPrecio(decimal precio) =>
            platos.Where(p => p.Precio < precio).ToList();
    }
}
