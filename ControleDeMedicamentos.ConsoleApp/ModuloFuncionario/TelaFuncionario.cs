using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : TelaBase<Funcionario>
    {
        private readonly TelaEndereco _telaEndereco;

        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario, TelaEndereco telaEndereco) : base(repositorioFuncionario)
        {

            _telaEndereco = telaEndereco;
            nomeEntidade = "Funcionário";
            sufixo = "s";
        }

        protected override void MostrarTabela(List<Funcionario> registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Telefone");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Funcionario funcionario in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", funcionario.Id, funcionario.Nome, funcionario.Telefone);
            }
        }

        protected override Funcionario ObterRegistro()
        {
            Endereco endereco = ObterEndereco();

            Console.Clear();

            Console.WriteLine("------ Cadastrar Funcionario ------");
            Console.WriteLine();

            Console.Write(">> Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write(">> Digite o login: ");
            string login = Console.ReadLine();

            Console.Write(">> Digite o senha: ");
            string senha = Console.ReadLine();

            Console.Write(">> Digite o telefone: ");
            string telefone = Console.ReadLine();

            Funcionario funcionario = new(nome, login, senha, telefone, endereco);

            return funcionario;
        }

        private Endereco ObterEndereco()
        {
            _telaEndereco.VisualizarRegistros(true);

            Endereco endereco = _telaEndereco.EncontrarRegistro("Digite o id do registro: ");

            Console.WriteLine();

            return endereco;
        }
    }
}
