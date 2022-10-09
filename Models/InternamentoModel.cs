using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace myAPI.Models

{
    public class InternamentoModel
    {
		[Key]
        public int InternamentoId { get; set; }
		public string? Competencia { get; set; }
		public string? DataInt { get; set; }
		public string? DataAlta { get; set; }
		public string? Leito { get; set; }
		public string? CID { get; set; }
		public string? Carater_Atendimento { get; set; }
		public string? Motivo_Encerramento { get; set; }

		[ForeignKey("PacienteID")]
		public int PacienteId { get; set; }

		public virtual List<PacienteModel> Pacientes { get; set; }
		public virtual List<ProcedimentoModel> Procedimentos { get; set; }
		
	}
}