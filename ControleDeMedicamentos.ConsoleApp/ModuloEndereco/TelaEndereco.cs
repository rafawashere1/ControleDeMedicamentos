using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloEndereco
{
    public class TelaEndereco : TelaBase<Endereco>
    {

        public TelaEndereco(RepositorioEndereco repositorioEndereco) : base(repositorioEndereco)
        {
            
        }

        protected override void MostrarTabela(List<Endereco> registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Rua", "Numero da Casa");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Endereco endereco in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", endereco.Id, endereco.Rua, endereco.NumeroCasa);
            }
        }

        protected override Endereco ObterRegistro()
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

            return new(rua, cidade, estado, pais, numeroCasa);
        }
    }
}
