using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuiviCompresseur.GestionCompresseur.Data.Context;
using SuiviCompresseur.GestionCompresseur.Domain.Models;
//using SuiviCompresseur.GestionCompresseur.Application.Services;
using SuiviCompresseur.GestionCompresseur.Domain.Interfaces;
//using SuiviCompresseur.GestionCompresseur.Application.Interfaces;
using MediatR;
using SuiviCompresseur.GestionCompresseur.Domain.Queries;
using SuiviCompresseur.GestionCompresseur.Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SuiviCompresseur.GestionCompresseur.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class CompresseurFilialesController : ControllerBase
    {
        
        private readonly CompresseurDbContext _context;
        private readonly IMediator mediator;


        public CompresseurFilialesController(CompresseurDbContext context, IMediator mediator)
        {
            this.mediator = mediator;
            _context = context;
        }

        // GET: api/CompresseurFiliales
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CompresseurFiliale>> GetCompresseursFiliale() =>
            await mediator.Send(new GetAllGenericQuery<CompresseurFiliale>());


        // GET: api/CompresseurFiliales/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<CompresseurFiliale> GetCompresseurFiliale(Guid id) =>
            await mediator.Send(new GetGenericQuery<CompresseurFiliale>(id));


        // POST: api/CompresseurFiliales
        [AllowAnonymous]
        [HttpPost]
        public async Task<string> PostCompresseurFiliale([FromBody] CompresseurFiliale compresseurFiliale) =>
            await mediator.Send(new CreateGenericCommand<CompresseurFiliale>(compresseurFiliale));

        // PUT: api/CompresseurFiliales/5
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<string> PutCompresseurFiliale([FromRoute] Guid id, [FromBody] CompresseurFiliale compresseurFiliale) =>
            await mediator.Send(new PutGenericCommand<CompresseurFiliale>(id, compresseurFiliale));

        // DELETE: api/CompresseurFiliales/5
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<string> DeleteCompresseurFiliale(Guid id) =>
            await mediator.Send(new RemoveGenericCommand<CompresseurFiliale>(id));



    }
}

