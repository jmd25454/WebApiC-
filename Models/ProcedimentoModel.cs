using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace myAPI.Models
{
    public class ProcedimentoModel
    {
		[Key]
        public int ProcedimentoId { get; set; }
		public string? Medico { get; set; }
		public string? Codigo { get; set; }
		public string? DescProcedimento { get; set; }
		public int QtdProcedimento { get; set; }
		[ForeignKey("PacienteID")]
		public int PacienteId { get; set; }

    }
}