namespace Backend.Domain.Entities
{
    public class Credencial
    {
        public int Id { get; private set; }
        public string NomeUsuario { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;

        private Credencial() { }

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
