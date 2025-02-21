using L01_2021_EC_601_2021_MG_603.Models;
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
        // Renombrada la lista para evitar conflictos con el nombre de la clase
        private static List<motoristas> _motoristasList = new List<motoristas>();

        [HttpGet]
        public ActionResult<IEnumerable<motoristas>> GetMotoristas() => _motoristasList;

        [HttpGet("{id}")]
        public ActionResult<motoristas> GetMotorista(int id)
        {
            var motorista = _motoristasList.FirstOrDefault(m => m.motoristaId == id);
            if (motorista == null)
                return NotFound();
            return motorista;
        }

        [HttpPost]
        public ActionResult<motoristas> CreateMotorista(motoristas nuevoMotorista)
        {
            _motoristasList.Add(nuevoMotorista);
            return CreatedAtAction(nameof(GetMotorista), new { id = nuevoMotorista.motoristaId }, nuevoMotorista);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMotorista(int id, motoristas updatedMotorista)
        {
            var existingMotorista = _motoristasList.FirstOrDefault(m => m.motoristaId == id);
            if (existingMotorista == null)
                return NotFound();

            // Actualizamos la propiedad existente
            existingMotorista.nombreMotorista = updatedMotorista.nombreMotorista;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMotorista(int id)
        {
            var motoristaToDelete = _motoristasList.FirstOrDefault(m => m.motoristaId == id);
            if (motoristaToDelete == null)
                return NotFound();

            _motoristasList.Remove(motoristaToDelete);
            return NoContent();
        }

        [HttpGet("filtrarPorNombre/{nombre}")]
        public ActionResult<IEnumerable<motoristas>> GetMotoristasPorNombre(string nombre) =>
            _motoristasList.Where(m => m.nombreMotorista.Contains(nombre)).ToList();
    }
}


