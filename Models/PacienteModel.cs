using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using myAPI.Data;

namespace myAPI.Models
{
    public class PacienteModel
    {
		[Key]
        public int PacienteId { get; set; }
		public string? Nome { get; set; }
    	public string? DataNasc { get; set; }
		public string? Sexo { get; set; }
		public string? Telefone { get; set; }
		
    }
}