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
using SuiviCompresseur.GestionCompresseur.Domain.Commands;
using SuiviCompresseur.GestionCompresseur.Domain.Queries;
using SuiviCompresseur.GestionCompresseur.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using SuiviCompresseur.GestionCompresseur.Domain.Queries.Fiche_SuiviQueries;
//using SuiviCompresseur.GestionCompresseur.Domain.Commands.Fiche_SuiviCommands;

namespace SuiviCompresseur.GestionCompresseur.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class Fiche_SuiviController : ControllerBase
    {

        private readonly CompresseurDbContext _context;
        private readonly IMediator mediator;

        public Fiche_SuiviController(CompresseurDbContext context, IMediator mediator)
        {
            _context = context;
            this.mediator = mediator;
        }


        // GET: api/Fiche_Suivis
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Fiche_Suivi>> GetFiche_Suivis() =>

            await mediator.Send(new GetAllGenericQuery<Fiche_Suivi>());


        // GET: api/Fiche_Suivis/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<Fiche_Suivi> GetFiche_Suivi(Guid id) =>

            await mediator.Send(new GetGenericQuery<Fiche_Suivi>(id));


        // PUT: api/Fiche_Suivis/5
        [Authorize(Roles = "TotalControl , LimitedAccess")]
        [HttpPut("{id}")]
        public async Task<string> PutFiche_Suivi([FromRoute] Guid id, [FromBody] Fiche_Suivi fiche_Suivi)
        {
            ValidationContraint validationFiche_Suivi = new ValidationContraint(_context);
            
            string testval = validationFiche_Suivi.testPut(fiche_Suivi,id);

            if (testval == "true")
            {
                return await mediator.Send(new PutGenericCommand<Fiche_Suivi>(id, fiche_Suivi));
            }
            else
                return testval;
        }



        // POST: api/Fiche_Suivis
        [Authorize(Roles = "TotalControl , LimitedAccess")]
        [HttpPost]
        public async Task<ActionResult<string>> PostFiche_Suivi([FromBody] Fiche_Suivi fiche_Suivi)
        {
            ValidationContraint validationFiche_Suivi = new ValidationContraint(_context);

            string testval = validationFiche_Suivi.testPost(fiche_Suivi);

            if (testval == "true")
            {
                return await mediator.Send(new CreateGenericCommand<Fiche_Suivi>(fiche_Suivi));
            }
            else
                return testval;
        }



        // DELETE: api/Fiche_Suivis/5
        [Authorize(Roles = "TotalControl , LimitedAccess")]
        [HttpDelete("{id}")]
        public async Task<string> DeleteFiche_Suivi(Guid id) =>
            await mediator.Send(new RemoveGenericCommand<Fiche_Suivi>(id));







    }
}
