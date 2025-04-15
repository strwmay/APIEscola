using System.ComponentModel.DataAnnotations;

namespace APIEscola.Models
{
    public class Turma
    {
        public Guid TurmaId { get; set; } // Identificador único da turma

        [Required(ErrorMessage = "O campo Curso é obrigatório.")]
        public Guid CursoId { get; set; } // Identificador do curso associado à turma

        [Required(ErrorMessage = "O campo Data de Inicio é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "A Data de Inicio deve ser uma data válida.")]
        public DateTime DataInicio { get; set; } // Data de início da turma

        [Required(ErrorMessage = "O campo Data de Fim é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "A Data de Fim deve ser uma data válida.")]
        public DateTime DataFim { get; set; } // Data de término da turma

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(200, ErrorMessage = "O Descrição deve ter no máximo 200 caracteres.")]
        public string Descrição { get; set; } // Descrição da turma

        [Required(ErrorMessage = "O campo Sigla é obrigatório.")]
        [StringLength(10, ErrorMessage = "O Sigla deve ter no máximo 10 caracteres.")]
        public string Sigla { get; set; } // Sigla da turma
    }
}
