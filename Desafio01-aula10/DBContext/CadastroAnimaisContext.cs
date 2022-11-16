using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Desafio01_aula10.Models;

namespace Desafio01_aula10.DBContext
{
    public class CadastroAnimaisContext : DbContext
    {
        public CadastroAnimaisContext() : base("CadastroAnimaisConnection")
        {

        }

        public DbSet<Cachorro> Cachorros { get; set; }
        public DbSet<Gato> Gatos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cachorro>().ToTable("TBCachorro");
            modelBuilder.Entity<Cachorro>().Property(p => p.nome).IsRequired().HasMaxLength(16);
            modelBuilder.Entity<Cachorro>().Property(p => p.nome).IsRequired();

            modelBuilder.Entity<Gato>().ToTable("TBGato");
            modelBuilder.Entity<Gato>().Property(p => p.nome).IsRequired().HasMaxLength(16);
            modelBuilder.Entity<Gato>().Property(p => p.nome).IsRequired();
        }
    }
}