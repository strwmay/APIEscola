using System.ComponentModel.DataAnnotations;

namespace APIEscola.Models
{
    public class Curso
    {
        public Guid CursoId { get; set; } // Identificador único do curso

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(10, ErrorMessage = "O Nome deve ter no máximo 10 caracteres.")]
        public string Sigla { get; set; } // Sigla do curso

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(250, ErrorMessage = "A Descrição deve ter no máximo 250 caracteres.")]
        public string Descricao { get; set; } // Descrição do curso

    }
}
