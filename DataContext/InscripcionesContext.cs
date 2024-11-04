//using BackClub.Models;
//using Microsoft.EntityFrameworkCore;

//namespace BackClub.DataContext
//{
//    public class InscripcionesContext : DbContext
//    {
//        public InscripcionesContext(DbContextOptions<InscripcionesContext> options) : base(options)
//        {
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            var configuration = new ConfigurationBuilder()
//                .AddJsonFile("appsettings.json")
//                .Build();

//            string cadenaConexion = configuration.GetConnectionString("mysqlremoto");

//            optionsBuilder.UseMySql(cadenaConexion,
//                                    ServerVersion.AutoDetect(cadenaConexion));
//        }

//        public virtual DbSet<Deporte> deportes { get; set; }
//        public virtual DbSet<Deportista> deportistas { get; set; }
//        public virtual DbSet<Profesor> profesores { get; set; }
//        public virtual DbSet<Cuota> cuotas { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Datos de semilla para Deporte
//            modelBuilder.Entity<Deporte>().HasData(
//                new Deporte { Id = 1, Nombre = "Fútbol", Descripcion = "Deporte de equipo", Hora = new TimeSpan(18, 0, 0) },
//                new Deporte { Id = 2, Nombre = "Basquetbol", Descripcion = "Deporte de equipo", Hora = new TimeSpan(19, 0, 0) },
//                new Deporte { Id = 3, Nombre = "Natación", Descripcion = "Deporte individual", Hora = new TimeSpan(17, 0, 0) }
//            );

//            // Datos de semilla para Profesor
//            modelBuilder.Entity<Profesor>().HasData(
//                new Profesor { Id = 1, Nombre = "Marcelo", Apellido = "Molina", Telefono = "123456789", DeporteId = 1 },
//                new Profesor { Id = 2, Nombre = "Renzo", Apellido = "Giunta", Telefono = "987654321", DeporteId = 2 },
//                new Profesor { Id = 3, Nombre = "Camila", Apellido = "Valiente", Telefono = "456123789", DeporteId = 3 }
//            );

//            // Datos de semilla para Deportista
//            modelBuilder.Entity<Deportista>().HasData(
//                new Deportista { Id = 1, ApellidoNombre = "Carlos López", Telefono = "321654987", Direccion = "Calle Falsa 123", Email = "carlos@example.com", DeporteId = 1 },
//                new Deportista { Id = 2, ApellidoNombre = "María Fernández", Telefono = "654987321", Direccion = "Avenida Siempre Viva 742", Email = "maria@example.com", DeporteId = 2 },
//                new Deportista { Id = 3, ApellidoNombre = "Pedro Sánchez", Telefono = "789321654", Direccion = "Boulevard de los Sueños Rotos", Email = "pedro@example.com", DeporteId = 3 }
//            );

//            // Datos de semilla para Cuota
//            modelBuilder.Entity<Cuota>().HasData(
//                new Cuota { Id = 1, Monto = 50.00m, FechaPago = DateTime.Now.AddMonths(-1), EstadoPago = "pagado", DeportistaId = 1 },
//                new Cuota { Id = 2, Monto = 50.00m, FechaPago = DateTime.Now.AddMonths(-2), EstadoPago = "pendiente", DeportistaId = 2 },
//                new Cuota { Id = 3, Monto = 50.00m, FechaPago = DateTime.Now.AddMonths(-1), EstadoPago = "pagado", DeportistaId = 3 }
//            );
//        }
//    }
//    }
using BackClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace BackClub.DataContext
{
    public class InscripcionesContext : DbContext
    {
        public InscripcionesContext(DbContextOptions<InscripcionesContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string cadenaConexion = configuration.GetConnectionString("mysqlremoto");

            optionsBuilder.UseMySql(cadenaConexion,
                                    ServerVersion.AutoDetect(cadenaConexion));
        }

        public virtual DbSet<Deporte> deportes { get; set; }
        public virtual DbSet<Deportista> deportistas { get; set; }
        public virtual DbSet<Profesor> profesores { get; set; }
        public virtual DbSet<Cuota> cuotas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Datos de semilla para Deporte
            modelBuilder.Entity<Deporte>().HasData(
                new Deporte { Id = 1, Nombre = "Fútbol", Descripcion = "Deporte de equipo", Hora = new TimeSpan(18, 0, 0) },
                new Deporte { Id = 2, Nombre = "Basquetbol", Descripcion = "Deporte de equipo", Hora = new TimeSpan(19, 0, 0) },
                new Deporte { Id = 3, Nombre = "Natación", Descripcion = "Deporte individual", Hora = new TimeSpan(17, 0, 0) }
            );

            // Datos de semilla para Profesor
            modelBuilder.Entity<Profesor>().HasData(
                new Profesor { Id = 1, Nombre = "Marcelo", Apellido = "Molina", Telefono = "123456789", DeporteId = 1 },
                new Profesor { Id = 2, Nombre = "Renzo", Apellido = "Giunta", Telefono = "987654321", DeporteId = 2 },
                new Profesor { Id = 3, Nombre = "Camila", Apellido = "Valiente", Telefono = "456123789", DeporteId = 3 }
            );

            // Datos de semilla para Deportista
            modelBuilder.Entity<Deportista>().HasData(
                new Deportista { Id = 1, ApellidoNombre = "Carlos López", Telefono = "321654987", Direccion = "Calle Falsa 123", Email = "carlos@example.com", DeporteId = 1 },
                new Deportista { Id = 2, ApellidoNombre = "María Fernández", Telefono = "654987321", Direccion = "Avenida Siempre Viva 742", Email = "maria@example.com", DeporteId = 2 },
                new Deportista { Id = 3, ApellidoNombre = "Pedro Sánchez", Telefono = "789321654", Direccion = "Boulevard de los Sueños Rotos", Email = "pedro@example.com", DeporteId = 3 }
            );

            // Datos de semilla para Cuota
            modelBuilder.Entity<Cuota>().HasData(
                new Cuota { Id = 1, Monto = 50.00m, FechaPago = DateTime.Now.AddMonths(-1), EstadoPago = "pagado", DeportistaId = 1 },
                new Cuota { Id = 2, Monto = 50.00m, FechaPago = DateTime.Now.AddMonths(-2), EstadoPago = "pendiente", DeportistaId = 2 },
                new Cuota { Id = 3, Monto = 50.00m, FechaPago = DateTime.Now.AddMonths(-1), EstadoPago = "pagado", DeportistaId = 3 }
            );
        }
    }
}
