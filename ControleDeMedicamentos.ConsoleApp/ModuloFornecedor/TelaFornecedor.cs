using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : TelaBase<Fornecedor>
    {
        private readonly TelaEndereco _telaEndereco;

        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor, TelaEndereco telaEndereco) : base(repositorioFornecedor)
        {
            
            _telaEndereco = telaEndereco;
            nomeEntidade = "Fornecedor";
            sufixo = "es";
        }

        protected override void MostrarTabela(List<Fornecedor> registros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Telefone");

            Console.WriteLine("--------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Fornecedor fornecedor in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", fornecedor.Id, fornecedor.Nome, fornecedor.Telefone);
            }
        }


        protected override Fornecedor ObterRegistro()
        {
            Endereco endereco = ObterEndereco();

            Console.Clear();

            Console.WriteLine("------ Cadastrar Fornecedor ------");
            Console.WriteLine();

            Console.Write(">> Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write(">> Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write(">> Digite o e-mail: ");
            string email = Console.ReadLine();

            return new Fornecedor(nome, telefone, email, endereco);
        }

        private Endereco ObterEndereco()
        {
            _telaEndereco.VisualizarRegistros(false);

            Endereco endereco = _telaEndereco.EncontrarRegistro("Digite o ID do endereço");

            Console.WriteLine();

            return endereco;
        }
    }
}
