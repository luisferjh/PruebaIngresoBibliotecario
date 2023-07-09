using Application.Contratos;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpGet("{identificacion}")]        
        public async Task<ActionResult> Get([FromRoute] string identificacion)
        {
            if (string.IsNullOrEmpty(identificacion))
                return BadRequest(new { mensaje = "Debe proporcionar un numero de identificación" });

            Guid guid;
            if (!Guid.TryParse(identificacion, out guid))                                    
                return BadRequest(new { mensaje = "Debe proporcionar un numero de identificación valido" });
            

            var prestamo = await _prestamoService.GetPrestamoAsync(guid);

            if (prestamo == null)
                return NotFound(new { mensaje = $"El prestamo con id {identificacion} no existe" });

            return Ok(prestamo);
        }

        [HttpPost]
        public async Task<ActionResult> AddPrestamo([FromBody] CreatePrestamoDTO createPrestamoDTO) 
        {
            if (!ModelState.IsValid)
                return BadRequest(new 
                {
                    mensaje = "ha ocurrido un error en la validación del objeto"
                });

            Guid guid;
            if (!Guid.TryParse(createPrestamoDTO.Isbn.ToString(), out guid))
                return BadRequest(new { mensaje = "Debe proporcionar un numero de identificación valido" });

            var responseService = await _prestamoService.InsertPrestamoAsync(createPrestamoDTO);
            if (!responseService.Result)
            {
                return BadRequest(responseService.Response);
            }

            return Ok(responseService.Response);
        }
    }
}
