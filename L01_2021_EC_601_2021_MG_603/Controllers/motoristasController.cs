using MiApiRestaurante.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MiApiRestaurante.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristasController : ControllerBase
    {
        private static List<Motorista> motoristas = new List<Motorista>();

        [HttpGet]
        public ActionResult<IEnumerable<Motorista>> GetMotoristas() => motoristas;

        [HttpGet("{id}")]
        public ActionResult<Motorista> GetMotorista(int id)
        {
            var motorista = motoristas.FirstOrDefault(m => m.Id == id);
            if (motorista == null) return NotFound();
            return motorista;
        }

        [HttpPost]
        public ActionResult<Motorista> CreateMotorista(Motorista motorista)
        {
            motoristas.Add(motorista);
            return CreatedAtAction(nameof(GetMotorista), new { id = motorista.Id }, motorista);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMotorista(int id, Motorista motorista)
        {
            var existing = motoristas.FirstOrDefault(m => m.Id == id);
            if (existing == null) return NotFound();

            existing.Nombre = motorista.Nombre;
            existing.Telefono = motorista.Telefono;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMotorista(int id)
        {
            var motorista = motoristas.FirstOrDefault(m => m.Id == id);
            if (motorista == null) return NotFound();

            motoristas.Remove(motorista);
            return NoContent();
        }

        [HttpGet("filtrarPorNombre/{nombre}")]
        public ActionResult<IEnumerable<Motorista>> GetMotoristasPorNombre(string nombre) =>
            motoristas.Where(m => m.Nombre.Contains(nombre)).ToList();
