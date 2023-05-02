namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int Id { get; internal set; }

        private static int contador = 0;

        public EntidadeBase()
        {
            Id = ++contador;
        }

        public abstract void AtualizarInformacoes(EntidadeBase registroAtualizado);

        public abstract List<string> Validar();
    }
}
