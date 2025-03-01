namespace Api.Models.Credenciais
{
    public class UpdateCredencialModel
    {
        public int Id { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Senha { get; set; }
    }
}
