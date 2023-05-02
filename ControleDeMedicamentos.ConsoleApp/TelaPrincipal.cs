namespace ControleDeMedicamentos.ConsoleApp
{
    public static class TelaPrincipal
    {
        public static string ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("------ Controle de Medicamentos ------");
            Console.WriteLine();

            Console.WriteLine("[1] Menu de Paciente");
            Console.WriteLine("[2] Menu de Funcionario");
            Console.WriteLine("[3] Menu de Medicamento");
            Console.WriteLine("[4] Menu de Fornecedor");
            Console.WriteLine("[5] Menu de Requisições de Entrada");
            Console.WriteLine("[6] Menu de Requisições de Saída");
            Console.WriteLine();
            Console.WriteLine("[S] Fechar o programa");

            Console.WriteLine();
            Console.Write("Digite uma opcão: ");

            return Console.ReadLine().ToUpper();
        }
    }
}