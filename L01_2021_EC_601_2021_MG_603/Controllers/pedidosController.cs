using MiApiRestaurante.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MiApiRestaurante.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private static List<Pedido> pedidos = new List<Pedido>();

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetPedidos() => pedidos;

        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound();
            return pedido;
        }

        [HttpPost]
        public ActionResult<Pedido> CreatePedido(Pedido pedido)
        {
            pedidos.Add(pedido);
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePedido(int id, Pedido pedido)
        {
            var existing = pedidos.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();

            existing.ClienteId = pedido.ClienteId;
            existing.MotoristaId = pedido.MotoristaId;
            existing.Fecha = pedido.Fecha;
            existing.Total = pedido.Total;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound();

            pedidos.Remove(pedido);
            return NoContent();
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult<IEnumerable<Pedido>> GetPedidosPorCliente(int clienteId) =>
            pedidos.Where(p => p.ClienteId == clienteId).ToList();

        [HttpGet("motorista/{motoristaId}")]
        public ActionResult<IEnumerable<Pedido>> GetPedidosPorMotorista(int motoristaId) =>
            pedidos.Where(p => p.MotoristaId == motoristaId).ToList();
    }
}
