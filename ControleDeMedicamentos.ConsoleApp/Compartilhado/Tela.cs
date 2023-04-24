namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    internal class Tela
    {
        public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();

            Console.ForegroundColor = cor;

            Console.WriteLine(mensagem);

            Console.ResetColor();

        }

        public static void VoltarAoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para voltar ao menu");
            Console.ReadKey();
        }
    }
}
