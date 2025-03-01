namespace Api.DTOs.Credenciais
{
    public class AddCredencialDto
    {
        public required string NomeUsuario { get; set; }
        public required string Senha { get; set; }
    }
}
