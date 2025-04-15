using System.ComponentModel.DataAnnotations;

namespace APIEscola.Models
{
    public class Matricula
    {
        public Guid MatriculaId { get; set; }

        [Required(ErrorMessage = "O Campo Aluno é Obrigatório")]
        public Guid AlunoId { get; set; }
        public Aluno? Aluno { get; set; }

        [Required(ErrorMessage = "O Campo Turma é Obrigatório")]
        public Guid TurmaId { get; set; }
        public Turma? Turma { get; set; }

        [Required(ErrorMessage = "O Campo Data de Matricula é Obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "O Formato da Data não é Valido.")]
        public DateTime DataMatricula { get; set; }
    }
}
