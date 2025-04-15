using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace APIEscola
{
    public class Aluno
    {
        public Guid AlunoId { get; set; } // Identificador único do aluno

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string CPF { get; set; } // CPF do aluno

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } // Nome do aluno

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "A Data de Nascimento deve ser uma data válida.")]
        public DateOnly DataNascimento { get; set; } // Data de nascimento do aluno

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [StringLength(11, ErrorMessage = "O Telefone deve ter no máximo 11 caracteres.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O Telefone deve conter apenas números.")]
        public string Telefone { get; set; } // Telefone do aluno

        public Guid? UserId { get; set; } // Identificador do usuário associado ao aluno
        public IdentityUser User { get; set; } // Navegação para o usuário associado
    }
}
