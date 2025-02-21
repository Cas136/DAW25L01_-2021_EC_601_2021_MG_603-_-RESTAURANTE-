using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2021_EC_601_2021_MG_603.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace L01_2021_EC_601_2021_MG_603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pedidosController : ControllerBase
    {
        private readonly restauranteContext _restauranteContexto;

        public pedidosController(restauranteContext restauranteContexto)
        {
            _restauranteContexto = restauranteContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<pedidos> listadoPedidos = (from p in _restauranteContexto.pedidos
                                            select p).ToList();
            if (listadoPedidos.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoPedidos);
        }
    }
}
