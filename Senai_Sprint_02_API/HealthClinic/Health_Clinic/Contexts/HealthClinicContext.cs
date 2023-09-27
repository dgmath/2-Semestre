using Microsoft.EntityFrameworkCore;
using Health_Clinic.Domains;


namespace Health_Clinic.Contexts
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Consulta> Consulta { get; set; }

        public DbSet<Situacao> Situacao { get; set; }

        public DbSet<FeedBack> FeedBack { get; set; }

        public DbSet<Especialidade> Especialidade { get; set; }

        public DbSet<Clinica> Clinica { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE15-S14; Database=Health_Clinic_Tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
