using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Aplicacion;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IValidator<Nuevo.Ejecuta> _validator;

        public AutorController(IMediator mediator, IValidator<Nuevo.Ejecuta> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            ValidationResult result = await _validator.ValidateAsync(data);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> GetAutores()
        {
            return await _mediator.Send(new Consulta.ListaAutor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutor(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.AutorUnico{ AutorGuid = id });
        }
    }
}
