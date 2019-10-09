using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuiviCompresseur.GestionCompresseur.Data.Context;
using SuiviCompresseur.GestionCompresseur.Domain.Models;
//using SuiviCompresseur.GestionCompresseur.Application.Interfaces;
using MediatR;
using SuiviCompresseur.GestionCompresseur.Domain.Queries;
using SuiviCompresseur.GestionCompresseur.Domain.Commands;

namespace SuiviCompresseur.GestionCompresseur.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FicheCompresseursController : ControllerBase
    {

        private readonly CompresseurDbContext _context;
        private readonly IMediator mediator;

        public FicheCompresseursController(CompresseurDbContext context, IMediator mediator)
        {
            _context = context;
            this.mediator = mediator;
        }

        // GET: api/FicheCompresseurs
        [HttpGet]
        public async Task<IEnumerable<FicheCompresseur>> GetFicheCompresseurs() =>
            await mediator.Send(new GetAllGenericQuery<FicheCompresseur>());


        // GET: api/FicheCompresseurs/5
        [HttpGet("{id}")]
        public async Task<FicheCompresseur> GetFicheCompresseur(Guid id) =>
            await mediator.Send(new GetGenericQuery<FicheCompresseur>(id));


        // PUT: api/FicheCompresseurs/5
        [HttpPut("{id}")]
        public async Task<string> PutFicheCompresseur([FromRoute] Guid id, [FromBody] FicheCompresseur ficheCompresseur) =>
            await mediator.Send(new PutGenericCommand<FicheCompresseur>(id, ficheCompresseur));


        // POST: api/FicheCompresseurs
        [HttpPost]
        public async Task<ActionResult<string>> PostFicheCompresseur([FromBody] FicheCompresseur ficheCompresseur) =>
            await mediator.Send(new CreateGenericCommand<FicheCompresseur>(ficheCompresseur));


        // DELETE: api/FicheCompresseurs/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteFicheCompresseur(Guid id) =>
            await mediator.Send(new RemoveGenericCommand<FicheCompresseur>(id));


    }
}
