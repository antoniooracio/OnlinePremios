﻿using Microsoft.EntityFrameworkCore;
using OnlinePremios.Domain.Entities;
using System.Linq;


namespace OnlinePremios.Data.Orm
{

    public class OnlinePremiosContext : DbContext
    {
        public OnlinePremiosContext(DbContextOptions<OnlinePremiosContext> options)
            : base(options)
        {
        }

        public DbSet<Compra> Compra { get; set; }
        public DbSet<Sorteio> Sorteio { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // onde não tiver setado varchar e a propriedade for 
            // do tipo string fica valendo varchar(100)

            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                //property.SetColumnType("varchar(90)");                
            }
        }

    }
}
