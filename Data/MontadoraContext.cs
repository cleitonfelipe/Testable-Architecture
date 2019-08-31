using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class MontadoraContext : DbContext
    {
        private string connection = @"Data Source=NOTECLEITON;Initial Catalog=Empresa;Integrated Security=True";
            //@"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
        public DbSet<DomainCarro> Carros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
