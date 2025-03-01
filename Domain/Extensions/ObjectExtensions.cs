using System.Reflection;

namespace Domain.Extensions
{
    public static class ObjectExtensions
    {
        public static void AtualizarPropriedadesNaoNulas<TOrigem, TDestino>(this TDestino entidade, TOrigem valoresNovos)
        {
            var propriedadesOrigem = typeof(TOrigem).GetProperties();
            var propriedadesDestino = typeof(TDestino).GetProperties().ToDictionary(p => p.Name);

            foreach (var propriedadeOrigem in propriedadesOrigem)
            {
                if (!propriedadesDestino.TryGetValue(propriedadeOrigem.Name, out var propriedadeDestino))
                    continue;

                var novoValor = propriedadeOrigem.GetValue(valoresNovos);
                var tipo = propriedadeOrigem.PropertyType;

                // Para strings, verifica se não é nulo ou vazio
                if (tipo == typeof(string) && string.IsNullOrWhiteSpace(novoValor as string))
                    continue;

                // Para tipos numéricos ou objetos, verifica se não é nulo
                if (novoValor != null && propriedadeDestino.CanWrite)
                {
                    propriedadeDestino.SetValue(entidade, novoValor);
                }
            }
        }
    }
}
