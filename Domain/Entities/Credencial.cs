namespace Domain.Entities
{
    public class Credencial
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

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
