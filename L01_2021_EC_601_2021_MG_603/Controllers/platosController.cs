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
    public class platosController : ControllerBase
    {
        private readonly restauranteContext _restauranteContexto;

        public platosController(restauranteContext restauranteContexto)
        {
            _restauranteContexto = restauranteContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<platos> listadoPlatos = (from p in _restauranteContexto.platos
                                          select p).ToList();

            if (listadoPlatos.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoPlatos);
        }
    }
}
