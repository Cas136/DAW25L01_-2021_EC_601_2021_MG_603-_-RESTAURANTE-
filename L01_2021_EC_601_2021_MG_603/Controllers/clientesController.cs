using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2021_EC_601_2021_MG_603.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2021_EC_601_2021_MG_603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientesController : ControllerBase
    {
        private readonly restauranteContext _restauranteContexto;

        public clientesController(restauranteContext restauranteContexto)
        {
            _restauranteContexto = restauranteContexto;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<clientes> listadoClientes = (from e in _restauranteContexto.clientes select e).ToList();
            if (listadoClientes.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoClientes);
        }
    }
 

}


