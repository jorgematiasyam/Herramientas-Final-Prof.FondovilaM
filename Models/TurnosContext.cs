using Microsoft.EntityFrameworkCore;
using Turnos.Models;
namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones)
        : base(opciones)
        {
            
        }

        public DbSet<Especialidad> Especialidad {get; set; }
        public DbSet<Paciente> Paciente {get; set;}
        public DbSet<Medico> Medico { get; set; }
        
        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public DbSet<Turno> Turno {get; set;}
        public DbSet<Login> Login {get; set;}

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad => 
            {
                entidad.ToTable("Especialidad");

                entidad.HasKey(e => e.IdEspecialidad);

                entidad.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            }
            );


            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Paciente");
                entidad.HasKey(e => e.IdPaciente);
                entidad.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entidad.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entidad.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entidad.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entidad.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);


            }
            
            );

                modelBuilder.Entity<Medico>(entidad =>
        {
            entidad.ToTable("Medico");

            entidad.HasKey(m => m.IdMedico);

            entidad.Property(m => m.Nombre)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

            entidad.Property(m => m.Apellido)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

            entidad.Property(m => m.Direccion)
            .IsRequired()
            .HasMaxLength(250)
            .IsUnicode(false);

            entidad.Property(m => m.Telefono)
            .IsRequired()
            .HasMaxLength(20)
            .IsUnicode(false);

            entidad.Property(m => m.Email)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

            entidad.Property(m => m.HorarioAtencionDesde)
            .IsRequired()            
            .IsUnicode(false);

            entidad.Property(m => m.HorarioAtencionHasta)
            .IsRequired()            
            .IsUnicode(false);
        });
        
        modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new { x.IdMedico, x.IdEspecialidad });

        modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Medico)
        .WithMany(p => p.MedicoEspecialidad)
        .HasForeignKey(p => p.IdMedico);

        modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Especialidad)
        .WithMany(p => p.MedicoEspecialidad)
        .HasForeignKey(p => p.IdEspecialidad);


                modelBuilder.Entity<Turno>(entidad => 
                {
                    entidad.ToTable("Turno");
                    entidad.HasKey(m => m.IdTurno);
                    
                    entidad.Property(m => m.IdPaciente)
                    .IsRequired()
                    .IsUnicode(false);

                    entidad.Property(m => m.IdMedico)
                    .IsRequired()
                    .IsUnicode(false);

                    
                    entidad.Property(m => m.FechaHoraInicio)
                    .IsRequired()
                    .IsUnicode(false);
                    entidad.Property(m => m.FechaHoraFin)
                    .IsRequired()
                    .IsUnicode(false);
                }


                );

                modelBuilder.Entity<Turno>().HasOne(x => x.Paciente)
                .WithMany(p => p.Turno)
                .HasForeignKey(p => p.IdPaciente);

                modelBuilder.Entity<Turno>().HasOne(x => x.Medico)
                .WithMany(p => p.Turno)
                .HasForeignKey(p => p.IdMedico);


                modelBuilder.Entity<Login>(entidad => {entidad.ToTable("Login");
                entidad.HasKey(l => l.LoginId);
                entidad.Property(l => l.Usuario).IsRequired();
                entidad.Property(l => l.Password).IsRequired();    
                });        
        }
                



        }
        

    }

