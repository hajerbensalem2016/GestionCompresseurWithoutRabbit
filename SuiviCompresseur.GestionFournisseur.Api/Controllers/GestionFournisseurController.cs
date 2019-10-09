using SuiviCompresseur.GestionFournisseur.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SuiviCompresseur.GestionFournisseur.Application.Models;
using SuiviCompresseur.GestionFournisseur.Domain.Interfaces;
using SuiviCompresseur.GestionFournisseur.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SuiviCompresseur.GestionFournisseur.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GestionFournisseurController : ControllerBase
    {
        private readonly IFournisseurService _fournisseurService;
        private readonly IFournisseurRepository _db;

        public GestionFournisseurController(IFournisseurService fournisseurService, IFournisseurRepository db)
        {
            _fournisseurService = fournisseurService;
            _db = db;

        }

        // GET api/Fournisseur
        //[Authorize(Roles = "Editors")]
        //[Authorize(Roles = "Admin")]
       // [Authorize(Roles = "Editors, Admin, SupAdmin")]
        [HttpGet]
        public Task<IEnumerable<Fournisseur>> Get()
        {
            return _fournisseurService.GetFournisseurs();
        }

        [HttpPost]
        public Task<string> Post([FromBody] Fournisseur fournisseur)
        {

            return _fournisseurService.Creation(fournisseur);
            //_db.AddF(new Fournisseur()
            //{
            //    FournisseurID = fournisseurCreation.FournisseurID,
            //    Nom = fournisseurCreation.Nom,
            //    Adresse = fournisseurCreation.Adresse,
            //    Email = fournisseurCreation.Email
            //});
            //return Ok(fournisseurCreation);
        }
        // GET: api/fournisseur/5
        [HttpGet("{id}")]
        public Task<Fournisseur> GetFournisseur(Guid id)
        {
            return _fournisseurService.GetFournisseur(id);
        }
        // PUT: api/fournisseur/5
        [HttpPut("{id}")]
        public Task<string> PutFournisseur(Guid id, Fournisseur fournisseur)
        {
            return _fournisseurService.PutFournisseurs(id, fournisseur);
        }



        // DELETE: api/fournisseur/5
        [HttpDelete("{id}")]
        public Task<string> DeleteFournisseur(Guid id)
        {
            return _fournisseurService.DeleteFournisseurs(id);
        }
    }
}
