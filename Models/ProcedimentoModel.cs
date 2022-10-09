using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace myAPI.Models
{
    public class ProcedimentoModel
    {
		[Key]
        public int ProcedimentoId { get; set; }
		public string? Medico { get; set; }
		public string? MedicoCBO { get; set; }
		public string? Codigo_Procedimento { get; set; }
		public string? DescProcedimento { get; set; }
		public int QtdProcedimento { get; set; }
		
		[ForeignKey("InternamentoID")]
		public int InternamentoId { get; set; }
		[JsonIgnore]
		public InternamentoModel Internamento { get; set; }
    }
}