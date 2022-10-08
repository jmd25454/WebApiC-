//criar projeto:
//	dotnet new webabi -minimal -o NomeDoProjeto
//entrar na pasta:
//	cd NomeDoProjeto
//adicionar entity framework no console:
//	dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0
//	dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0
//	dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0
//incluir namespace do entity framework:
//	using Microsoft.EntityFrameworkCore;
//antes de rodar o dotnet run pela primeira vez, rodar os seguintes comandos para iniciar a base de dados:
//	dotnet ef migrations add InitialCreate
//	dotnet ef database update

using System;
using System.Linq;
using myAPI.Models;
using myAPI.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Trabalho
{
    partial class Program
	{
		static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			
			var connectionString = builder.Configuration.GetConnectionString("Hospital") ?? "Data Source=Hospital.db";
			builder.Services.AddSqlite<BaseHospital>(connectionString);
			
			var app = builder.Build();

			//listar todos os Pacientes
			app.MapGet("/pacientes", (BaseHospital baseHospital) => {
				return (baseHospital.Pacientes
				.ToList());
			});

			//listar todos os Procedimentos
			app.MapGet("/procedimentos", (BaseHospital baseHospital) => {
				return (baseHospital.Procedimentos.ToList());
			});

			//listar todos os Internamentos
			app.MapGet("/internamentos", (BaseHospital baseHospital) => {
				return (baseHospital.Internamentos.ToList());
			});
			
			//listar Paciente especifico (por id)
			app.MapGet("/paciente/{id}", (BaseHospital baseHospital, int id) => {
				return baseHospital.Pacientes.Find(id);
				});
			
			//cadastrar Paciente
			app.MapPost("/cadastrarPaciente", (BaseHospital baseHospital, PacienteModel Pacientes) =>
			{
				baseHospital.Pacientes.Add(Pacientes);
				baseHospital.SaveChanges();
				return "Paciente adicionado";
			});
			//cadastrar Procediemento
			app.MapPost("/cadastrarProcedimento", (BaseHospital baseHospital, ProcedimentoModel Procedimentos) =>
			{
				baseHospital.Procedimentos.Add(Procedimentos);
				baseHospital.SaveChanges();
				return "Procedimento adicionado";
			});

			//cadastrar Internamento
			app.MapPost("/cadastrarInternamento", (BaseHospital baseHospital, InternamentoModel Internamentos) =>
			{
				baseHospital.Internamentos.Add(Internamentos);
				baseHospital.SaveChanges();
				return "Internamento adicionado";
			});
			
			//atualizar Paciente
			app.MapPost("/atualizarPaciente/{id}", (BaseHospital baseHospital, PacienteModel PacienteAtualizado, int id) =>
			{
				var Paciente = baseHospital.Pacientes.Find(id);
				Paciente.Nome = PacienteAtualizado.Nome;
				Paciente.DataNasc = PacienteAtualizado.DataNasc;
				Paciente.Sexo = PacienteAtualizado.Sexo;
				Paciente.Telefone = PacienteAtualizado.Telefone;
				baseHospital.SaveChanges();
				return "Paciente atualizado";
			});

			//atualizar Procedimento
			app.MapPost("/atualizarProcedimento/{id}", (BaseHospital baseHospital, ProcedimentoModel ProcedimentoAtualizado, int id) =>
			{
				var Procedimento = baseHospital.Procedimentos.Find(id);
				Procedimento.Medico = ProcedimentoAtualizado.Medico;
				Procedimento.Codigo = ProcedimentoAtualizado.Codigo;
				Procedimento.DescProcedimento = ProcedimentoAtualizado.DescProcedimento;
				Procedimento.QtdProcedimento = ProcedimentoAtualizado.QtdProcedimento;
				baseHospital.SaveChanges();
				return "Procedimento atualizado";
			});

			//atualizar Internamento
			app.MapPost("/atualizarInternamento/{id}", (BaseHospital baseHospital, InternamentoModel InternamentoAtualizado, int id) =>
			{
				var Internamento = baseHospital.Internamentos.Find(id);
				Internamento.NumeroAIH = InternamentoAtualizado.NumeroAIH;
				Internamento.DataInt = InternamentoAtualizado.DataInt;
				Internamento.DataAlta = InternamentoAtualizado.DataAlta;
				baseHospital.SaveChanges();
				return "Internamento atualizado";
			});
						
			//deletar Paciente
			app.MapPost("/deletarPaciente/{id}", (BaseHospital baseHospital, int id) =>
			{
				var Paciente = baseHospital.Pacientes.Find(id);
				baseHospital.Remove(Paciente);
				baseHospital.SaveChanges();
				return "Paciente deletado";
			});

			//deletar Procedimento
			app.MapPost("/deletarProcedimento/{id}", (BaseHospital baseHospital, int id) =>
			{
				var Procedimento = baseHospital.Procedimentos.Find(id);
				baseHospital.Remove(Procedimento);
				baseHospital.SaveChanges();
				return "Procedimento deletado";
			});

			//deletar Internamento
			app.MapPost("/deletarInternamento/{id}", (BaseHospital baseHospital, int id) =>
			{
				var Internamento = baseHospital.Internamentos.Find(id);
				baseHospital.Remove(Internamento);
				baseHospital.SaveChanges();
				return "Internamento deletado";
			});

			app.Run();
		}
	}
}