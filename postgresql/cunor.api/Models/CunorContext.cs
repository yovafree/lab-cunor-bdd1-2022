using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cunor.api.Models
{
    public partial class CunorContext : DbContext
    {
        public CunorContext()
        {
        }

        public CunorContext(DbContextOptions<CunorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Alquiler> Alquilers { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Colaborador> Colaboradors { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Ejemplar> Ejemplars { get; set; }
        public virtual DbSet<EstadoEjemplar> EstadoEjemplars { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Productora> Productoras { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Puesto> Puestos { get; set; }
        public virtual DbSet<Reparto> Repartos { get; set; }
        public virtual DbSet<TipoActor> TipoActors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=12345678;Database=cunor;Port=5435");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.CodActor)
                    .HasName("pk_actor");

                entity.ToTable("actor");

                entity.Property(e => e.CodActor).HasColumnName("cod_actor");

                entity.Property(e => e.CodNacionalidad).HasColumnName("cod_nacionalidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(75)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(75)
                    .HasColumnName("sexo");

                entity.HasOne(d => d.CodNacionalidadNavigation)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(d => d.CodNacionalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refnacionalidad131");
            });

            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.CodAlquiler)
                    .HasName("pk_alquiler");

                entity.ToTable("alquiler");

                entity.Property(e => e.CodAlquiler).HasColumnName("cod_alquiler");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.CodEjemplar).HasColumnName("cod_ejemplar");

                entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");

                entity.Property(e => e.FecAlquiler)
                    .HasMaxLength(75)
                    .HasColumnName("fec_alquiler");

                entity.Property(e => e.FecDevolucion)
                    .HasMaxLength(75)
                    .HasColumnName("fec_devolucion");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Alquilers)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refcliente101");

                entity.HasOne(d => d.Cod)
                    .WithMany(p => p.Alquilers)
                    .HasForeignKey(d => new { d.CodEjemplar, d.CodPelicula })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refejemplar91");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("pk_cliente");

                entity.ToTable("cliente");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.CodClienteAval).HasColumnName("cod_cliente_aval");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(75)
                    .HasColumnName("direccion");

                entity.Property(e => e.Dni)
                    .HasMaxLength(75)
                    .HasColumnName("dni");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(75)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(75)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CodClienteAvalNavigation)
                    .WithMany(p => p.InverseCodClienteAvalNavigation)
                    .HasForeignKey(d => d.CodClienteAval)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refcliente111");
            });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.HasKey(e => e.CodColaborador)
                    .HasName("colaborador_pkey");

                entity.ToTable("colaborador");

                entity.Property(e => e.CodColaborador)
                    .HasColumnName("cod_colaborador")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(150)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Correo)
                    .HasColumnType("character varying")
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(150)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(30)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.CodCurso)
                    .HasName("curso_pkey");

                entity.ToTable("curso");

                entity.Property(e => e.CodCurso).HasColumnName("cod_curso");

                entity.Property(e => e.Carrera)
                    .HasColumnType("character varying")
                    .HasColumnName("carrera");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.CodDirector)
                    .HasName("pk_director");

                entity.ToTable("director");

                entity.Property(e => e.CodDirector).HasColumnName("cod_director");

                entity.Property(e => e.CodNacionalidad).HasColumnName("cod_nacionalidad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FecActualizacion)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fec_actualizacion");

                entity.Property(e => e.FecCreacion)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fec_creacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(75)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.CodNacionalidadNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.CodNacionalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refnacionalidad121");
            });

            modelBuilder.Entity<Ejemplar>(entity =>
            {
                entity.HasKey(e => new { e.CodEjemplar, e.CodPelicula })
                    .HasName("pk_ejemplar");

                entity.ToTable("ejemplar");

                entity.Property(e => e.CodEjemplar)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("cod_ejemplar");

                entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");

                entity.Property(e => e.CodEstadoEjemplar).HasColumnName("cod_estado_ejemplar");

                entity.HasOne(d => d.CodEstadoEjemplarNavigation)
                    .WithMany(p => p.Ejemplars)
                    .HasForeignKey(d => d.CodEstadoEjemplar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refestado_ejemplar181");

                entity.HasOne(d => d.CodPeliculaNavigation)
                    .WithMany(p => p.Ejemplars)
                    .HasForeignKey(d => d.CodPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refpelicula171");
            });

            modelBuilder.Entity<EstadoEjemplar>(entity =>
            {
                entity.HasKey(e => e.CodEstadoEjemplar)
                    .HasName("pk_estado_ejemplar");

                entity.ToTable("estado_ejemplar");

                entity.Property(e => e.CodEstadoEjemplar).HasColumnName("cod_estado_ejemplar");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(75)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.CodEstudiante)
                    .HasName("estudiante_pkey");

                entity.ToTable("estudiante");

                entity.Property(e => e.CodEstudiante).HasColumnName("cod_estudiante");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Carne)
                    .HasMaxLength(12)
                    .HasColumnName("carne");

                entity.Property(e => e.Carrera)
                    .HasMaxLength(50)
                    .HasColumnName("carrera");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(150)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.NoCelular)
                    .HasMaxLength(15)
                    .HasColumnName("no_celular");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nombres");

                entity.Property(e => e.TipoVivienda)
                    .HasMaxLength(75)
                    .HasColumnName("tipo_vivienda");
            });

            modelBuilder.Entity<Nacionalidad>(entity =>
            {
                entity.HasKey(e => e.CodNacionalidad)
                    .HasName("pk_nacionalidad");

                entity.ToTable("nacionalidad");

                entity.Property(e => e.CodNacionalidad).HasColumnName("cod_nacionalidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.CodPelicula)
                    .HasName("pk_pelicula");

                entity.ToTable("pelicula");

                entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");

                entity.Property(e => e.CodDirector).HasColumnName("cod_director");

                entity.Property(e => e.CodNacionalidad).HasColumnName("cod_nacionalidad");

                entity.Property(e => e.CodProductora).HasColumnName("cod_productora");

                entity.Property(e => e.FecEstreno)
                    .HasMaxLength(75)
                    .HasColumnName("fec_estreno");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(75)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.CodDirectorNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.CodDirector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refdirector51");

                entity.HasOne(d => d.CodNacionalidadNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.CodNacionalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refnacionalidad141");

                entity.HasOne(d => d.CodProductoraNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.CodProductora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refproductora151");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodProducto)
                    .HasName("producto_pkey");

                entity.ToTable("producto");

                entity.Property(e => e.CodProducto).HasColumnName("cod_producto");

                entity.Property(e => e.CodProveedor).HasColumnName("cod_proveedor");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.HasOne(d => d.CodProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("proveedor_producto_fk");
            });

            modelBuilder.Entity<Productora>(entity =>
            {
                entity.HasKey(e => e.CodProductora)
                    .HasName("pk_productora");

                entity.ToTable("productora");

                entity.Property(e => e.CodProductora).HasColumnName("cod_productora");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.CodProveedor)
                    .HasName("proveedor_pkey");

                entity.ToTable("proveedor");

                entity.Property(e => e.CodProveedor).HasColumnName("cod_proveedor");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre).HasColumnName("nombre");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.CodPuesto)
                    .HasName("puesto_pkey");

                entity.ToTable("puesto");

                entity.Property(e => e.CodPuesto)
                    .HasColumnName("cod_puesto")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .HasColumnName("nombre");

                entity.Property(e => e.Salario)
                    .HasPrecision(12, 2)
                    .HasColumnName("salario");
            });

            modelBuilder.Entity<Reparto>(entity =>
            {
                entity.HasKey(e => new { e.CodReparto, e.CodPelicula, e.CodActor, e.CodTipoActor })
                    .HasName("pk_reparto");

                entity.ToTable("reparto");

                entity.Property(e => e.CodReparto)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("cod_reparto");

                entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");

                entity.Property(e => e.CodActor).HasColumnName("cod_actor");

                entity.Property(e => e.CodTipoActor).HasColumnName("cod_tipo_actor");

                entity.HasOne(d => d.CodActorNavigation)
                    .WithMany(p => p.Repartos)
                    .HasForeignKey(d => d.CodActor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refactor31");

                entity.HasOne(d => d.CodPeliculaNavigation)
                    .WithMany(p => p.Repartos)
                    .HasForeignKey(d => d.CodPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Refpelicula21");

                entity.HasOne(d => d.CodTipoActorNavigation)
                    .WithMany(p => p.Repartos)
                    .HasForeignKey(d => d.CodTipoActor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reftipo_actor41");
            });

            modelBuilder.Entity<TipoActor>(entity =>
            {
                entity.HasKey(e => e.CodTipoActor)
                    .HasName("pk_tipo_actor");

                entity.ToTable("tipo_actor");

                entity.Property(e => e.CodTipoActor).HasColumnName("cod_tipo_actor");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(75)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
