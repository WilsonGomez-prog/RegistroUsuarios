using System;
using Microsoft.EntityFrameworkCore;
using RegistroUsuarios.Entidades;

namespace RegistroUsuarios.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=DATA\UsuariosBD.db");
        }

    }
}