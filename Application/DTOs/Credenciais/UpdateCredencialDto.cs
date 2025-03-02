namespace Application.DTOs.Credenciais
{
    public class UpdateCredencialDto
    {
        public int Id { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Senha { get; set; }
    }
}
