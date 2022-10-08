using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace myAPI.Models

{
    public class InternamentoModel
    {
		[Key]
        public int InternamentoId { get; set; }
		public int NumeroAIH { get; set; }
		public string DataInt { get; set; }
		public string DataAlta { get; set; }
		[ForeignKey("ProcedimentoID")]
		public int ProcedimentoId { get; set; }
	}
}