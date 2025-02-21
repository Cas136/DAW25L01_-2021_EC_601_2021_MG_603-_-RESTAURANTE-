using MiApiRestaurante.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MiApiRestaurante.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class motoristasController : ControllerBase
    {
        private static List<motoristas> motoristas = new List<motoristas>();

        [HttpGet]
        public ActionResult<IEnumerable<motoristas>> Getmotoristas() => motoristas;

        [HttpGet("{id}")]
        public ActionResult<motoristas> Getmotoristas(int id)
        {
            var motoristas = motoristas.FirstOrDefault(m => m.Id == id);
            if (motoristas == null) return NotFound();
            return motoristas;
        }

        [HttpPost]
        public ActionResult<motoristas> Createmotoristas(motoristas motoristas)
        {
            motoristas.Add(motoristas);
            return CreatedAtAction(nameof(Getmotoristas), new { id = motoristas.Id }, motoristas);
        }

        [HttpPut("{id}")]
        public IActionResult Updatemotoristas(int id, motoristas motoristas)
        {
            var existing = motoristas.FirstOrDefault(m => m.Id == id);
            if (existing == null) return NotFound();

            existing.Nombre = motoristas.Nombre;
            existing.Telefono = motoristas.Telefono;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletemotoristas(int id)
        {
            var motoristas = motoristas.FirstOrDefault(m => m.Id == id);
            if (motoristas == null) return NotFound();

            motoristas.Remove(motoristas);
            return NoContent();
        }

        [HttpGet("filtrarPorNombre/{nombre}")]
        public ActionResult<IEnumerable<motoristas>> GetmotoristasPorNombre(string nombre) =>
            motoristas.Where(m => m.Nombre.Contains(nombre)).ToList();
    }
}

