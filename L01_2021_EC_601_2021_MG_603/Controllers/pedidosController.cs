using MiApiRestaurante.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MiApiRestaurante.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class pedidosController : ControllerBase
    {
        private static List<pedidos> pedidos = new List<pedidos>();

        [HttpGet]
        public ActionResult<IEnumerable<pedidos>> Getpedidos() => pedidos;

        [HttpGet("{id}")]
        public ActionResult<pedidos> Getpedidos(int id)
        {
            var pedidos = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedidos == null) return NotFound();
            return pedidos;
        }

        [HttpPost]
        public ActionResult<pedidos> Createpedidos(pedidos pedidos)
        {
            pedidos.Add(pedidos);
            return CreatedAtAction(nameof(Getpedidos), new { id = pedidos.Id }, pedidos);
        }

        [HttpPut("{id}")]
        public IActionResult Updatepedidos(int id, pedidos pedidos)
        {
            var existing = pedidos.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();

            existing.ClienteId = pedidos.ClienteId;
            existing.MotoristaId = pedidos.MotoristaId;
            existing.Fecha = pedidos.Fecha;
            existing.Total = pedidos.Total;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletepedidos(int id)
        {
            var pedidos = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedidos == null) return NotFound();

            pedidos.Remove(pedidos);
            return NoContent();
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult<IEnumerable<pedidos>> GetpedidosPorCliente(int clienteId) =>
            pedidos.Where(p => p.ClienteId == clienteId).ToList();

        [HttpGet("motorista/{motoristaId}")]
        public ActionResult<IEnumerable<pedidos>> GetpedidosPorMotorista(int motoristaId) =>
            pedidos.Where(p => p.MotoristaId == motoristaId).ToList();
    }
}
