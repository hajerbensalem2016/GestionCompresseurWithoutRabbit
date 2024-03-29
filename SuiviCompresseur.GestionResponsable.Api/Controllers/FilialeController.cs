﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MediatR;

using System.Net;
using SuiviCompresseur.Gestion.Responsable.Aplication.Interfaces;
using SuiviCompresseur.Gestion.Responsable.Domain.Models;
using SuiviCompresseur.Gestion.Responsable.Aplication.Models;
using SuiviCompresseur.Gestion.Responsable.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SuiviCompresseur.GestionResponsable.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FilialeController : ControllerBase
    {
        private readonly IFilialeService _filialeService;

        private readonly IGenericRepositoryResponsable<Filiale> _db;


        public FilialeController(IFilialeService filialeService, IGenericRepositoryResponsable<Filiale> db)
        {
            _filialeService = filialeService;
            _db = db;
        }

        // GET api/Filiale
        //[AllowAnonymous]
        [Authorize(Roles = "Editors , TotalControl , LimitedAccess")]
        [HttpGet]
        public Task<IEnumerable<Filiale>> Get()
        {
            return _filialeService.GetFiliales();
        }

        // GET api/Filiale/5
        //[AllowAnonymous]
        [Authorize(Roles = "Editors , TotalControl , LimitedAccess")]
        [HttpGet("{id}")]
        public Task<Filiale> Get1(Guid id)
        {
            return _filialeService.GetFiliale(id);
        }

        // DELETE: api/Filiales/5
        [Authorize(Roles = "Editors , TotalControl")]
        [HttpDelete("{id}")]
        public Task<string> DeleteFiliale(Guid id)
        {
            return _filialeService.DeleteFiliale(id);
        }

        // PUT: api/Filiales/5
        [Authorize(Roles = "Editors , TotalControl")]
        [HttpPut("{id}")]
        public Task<string> PutFiliale(Guid id, [FromBody] Filiale Filiale)
        {
            return _filialeService.PutFiliale(id, Filiale);
        }


        [Authorize(Roles = "Editors , TotalControl")]
        [HttpPost]
        public Task<string> Post([FromBody] Filiale filiale)
        {
            return _filialeService.Transfer(filiale);
        }
    }
}
