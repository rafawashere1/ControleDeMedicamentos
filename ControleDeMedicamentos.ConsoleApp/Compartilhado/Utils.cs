namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public static class Utils
    {
        public static void VoltarAoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para voltar ao menu");
            Console.ReadKey();
        }

        public static void MostrarMensagem(string mensagem, ConsoleColor cor, TipoMensagem tipoMensagem)
        {
            switch (tipoMensagem)
            {
                case TipoMensagem.READKEY:

                    Console.WriteLine();
                    Console.ForegroundColor = cor;
                    Console.WriteLine(mensagem);
                    Console.ResetColor();
                    Console.ReadKey();
                    break;

                case TipoMensagem.NOREADKEY:

                    Console.WriteLine();
                    Console.ForegroundColor = cor;
                    Console.WriteLine(mensagem);
                    Console.ResetColor();

                    break;
            }
        }
    }
}
