namespace Domain.Entities
{
    public class Credencial
    {
        public int Id { get; set; }
        public required string NomeUsuario { get; set; }
        public required string Senha { get; set; }

        public Credencial() { }

        public static Credencial Create(string nomeUsuario, string senha)
        {
            return new Credencial
            {
                NomeUsuario = nomeUsuario,
                Senha = senha
            };
        }

        public void AtualizarSenha(string novaSenha)
        {
            Senha = novaSenha;
        }
    }
}
