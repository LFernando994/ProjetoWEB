using CLRegras;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace InfraWeb.Context
{
    public class ContextDB: DbContext
    {

        public ContextDB() : base("DefaultConnection")
       {
        
       }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Contato> Contatodb { get; set; }
        public DbSet<AreaDeAtuacao> Areas { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Chamado> Chamado { get; set; }

        public DbSet<PerfilUser> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}