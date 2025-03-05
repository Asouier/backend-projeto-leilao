namespace Application.DTOs.Credenciais
{
    public class LoginDto
    {
        public required string NomeUsuario { get; set; }
        public required string Senha { get; set; }
    }
}
