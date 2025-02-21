using L01_2021_EC_601_2021_MG_603.Models;
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
        // Lista estática para almacenar los pedidos
        private static List<pedidos> _pedidosList = new List<pedidos>();

        [HttpGet]
        public ActionResult<IEnumerable<pedidos>> GetPedidos() => _pedidosList;

        [HttpGet("{id}")]
        public ActionResult<pedidos> GetPedido(int id)
        {
            var pedido = _pedidosList.FirstOrDefault(p => p.pedidoId == id);
            if (pedido == null)
                return NotFound();
            return pedido;
        }

        [HttpPost]
        public ActionResult<pedidos> CreatePedido(pedidos nuevoPedido)
        {
            _pedidosList.Add(nuevoPedido);
            return CreatedAtAction(nameof(GetPedido), new { id = nuevoPedido.pedidoId }, nuevoPedido);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePedido(int id, pedidos pedidoActualizado)
        {
            var existing = _pedidosList.FirstOrDefault(p => p.pedidoId == id);
            if (existing == null)
                return NotFound();

            // Actualizamos las propiedades existentes
            existing.motoristaId = pedidoActualizado.motoristaId;
            existing.clienteId = pedidoActualizado.clienteId;
            existing.platoId = pedidoActualizado.platoId;
            existing.cantidad = pedidoActualizado.cantidad;
            existing.precio = pedidoActualizado.precio;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var pedido = _pedidosList.FirstOrDefault(p => p.pedidoId == id);
            if (pedido == null)
                return NotFound();

            _pedidosList.Remove(pedido);
            return NoContent();
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult<IEnumerable<pedidos>> GetPedidosPorCliente(int clienteId) =>
            _pedidosList.Where(p => p.clienteId == clienteId).ToList();

        [HttpGet("motorista/{motoristaId}")]
        public ActionResult<IEnumerable<pedidos>> GetPedidosPorMotorista(int motoristaId) =>
            _pedidosList.Where(p => p.motoristaId == motoristaId).ToList();
    }
}
