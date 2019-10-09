using SuiviCompresseur.GestionCompresseur.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuiviCompresseur.GestionCompresseur.Data.Context
{
    public class CompresseurDbContext : DbContext
    {
        public CompresseurDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CompresseurFiliale> CompresseurFiliales { get; set; }
        public DbSet<Consommable> Consommables { get; set; }
        public DbSet<Fiche_Suivi> Fiche_Suivis { get; set; }
        public DbSet<FicheCompresseur> FicheCompresseurs { get; set; }
   
        public DbSet<GRH> GRHs { get; set; }
        //hajer

    }
}
