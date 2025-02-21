using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2021_EC_601_2021_MG_603.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2021_EC_601_2021_MG_603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class motoristasController : ControllerBase
    {
        private readonly restauranteContext _restauranteContexto;

        public motoristasController(restauranteContext restauranteContexto)
        {
            _restauranteContexto = restauranteContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<motoristas> listadoMotoristas = (from m in _restauranteContexto.motoristas
                                                  select m).ToList();

            if (listadoMotoristas.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoMotoristas);
        }
    }
}
