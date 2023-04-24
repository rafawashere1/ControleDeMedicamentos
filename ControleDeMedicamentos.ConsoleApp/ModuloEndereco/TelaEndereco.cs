namespace ControleDeMedicamentos.ConsoleApp.ModuloEndereco
{
    internal class TelaEndereco
    {
        public Endereco ObterEndereco()
        {
            Console.Write(">> Digite a rua: ");
            string rua = Console.ReadLine();

            Console.Write(">> Digite o número da casa: ");
            string numeroCasa = Console.ReadLine();

            Console.Write(">> Digite a cidade: ");
            string cidade = Console.ReadLine();

            Console.Write(">> Digite o estado: ");
            string estado = Console.ReadLine();

            Console.Write(">> Digite o país: ");
            string pais = Console.ReadLine();

            Endereco endereco = new(rua, cidade, estado, pais, numeroCasa);

            return endereco;
        }
    }
}
