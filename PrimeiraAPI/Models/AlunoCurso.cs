namespace PrimeiraAPI.Models
{
    public class AlunoCurso
    {
        // Identificador único do registro de associação entre aluno e curso
        public Guid AlunoCursoId { get; set; }

        // Chave estrangeira para o aluno
        public Guid AlunoId { get; set; }

        // Propriedade de navegação para o aluno
        public Aluno? Aluno { get; set; }

        // Chave estrangeira para o curso
        public Guid CursoId { get; set; }

        // Propriedade de navegação para o curso
        public Curso? Curso { get; set; }
    }
}
