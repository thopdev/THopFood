using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ThopFood.API.Data.Entities;
using ThopFood.API.Extensions;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Responses;
using ThopFood.Shared.Requests.Utensil;
using ThopFood.Shared.Responses.EntityCreated;

namespace ThopFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtensilController : ControllerBase
    {
        private readonly IUtensilRepository _utensilRepository;
        private readonly IMapper _mapper;

        public UtensilController(IUtensilRepository utensilRepository, IMapper mapper)
        {
            _utensilRepository = utensilRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UtensilResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _utensilRepository.GetAllAsync(cancellationToken);

            return Ok(_mapper.MapIEnumerable<Utensil, UtensilResponse>(result));
        }

        [HttpGet("{id:int:required}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UtensilResponse>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _utensilRepository.GetByIdAsync(id, cancellationToken);

            if (result is null)
            {
                return NotFound($"{nameof(Utensil)} not found!");
            }

            return Ok(_mapper.Map<UtensilResponse>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EntityCreateResponse>> Create([FromBody] CreateUtensilRequest request,
            CancellationToken cancellationToken)
        {
            var id = await _utensilRepository.CreateAsync(request, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { Id = id }, new EntityCreateResponse(id));
        }
    }
}
