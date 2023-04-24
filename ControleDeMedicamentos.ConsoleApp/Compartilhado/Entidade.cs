namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    internal class Entidade
    {
        public int Id { get; internal set; }

        private static int contador = 0;

        public Entidade()
        {
            Id = ++contador;
        }
    }
}
