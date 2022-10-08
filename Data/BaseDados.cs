using myAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace myAPI.Data
{
    public class BaseHospital : DbContext
	{
		public BaseHospital(DbContextOptions options) : base(options)
		{
		}
		
		public DbSet<PacienteModel> Pacientes { get; set; } = null!;
		public DbSet<ProcedimentoModel> Procedimentos { get; set; } = null!;
		public DbSet<InternamentoModel> Internamentos { get; set; } = null!;
	}
}
