using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class TelaFuncionario : Tela
    {
        private readonly RepositorioFuncionario _repositorioFuncionario;
        private readonly TelaEndereco _telaEndereco;

        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario, TelaEndereco telaEndereco)
        {
            _repositorioFuncionario = repositorioFuncionario;
            _telaEndereco = telaEndereco;

        }

        public string ApresentarMenuFuncionario()
        {
            Console.Clear();

            Console.WriteLine("------ Controle de Funcionario ------");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar funcionário");
            Console.WriteLine("[2] Editar funcionário");
            Console.WriteLine("[3] Excluir funcionário");
            Console.WriteLine("[4] Visualizar funcionários");
            Console.WriteLine();
            Console.WriteLine("[S] Voltar ao menu principal");

            Console.WriteLine();
            Console.Write("Digite uma opção: ");

            string opcao = Console.ReadLine().ToUpper();

            return opcao;
        }

        public void InserirFuncionario()
        {
            Funcionario NovoFuncionario = ObterFuncionario();

            _repositorioFuncionario.Inserir(NovoFuncionario);
        }

        public void EditarFuncionario()
        {
            Console.Clear();

            Console.WriteLine("Editando funcionário..");
            Console.WriteLine();

            bool temFuncionario = VisualizarFuncionarios();

            if (temFuncionario == false)
            {
                VoltarAoMenu();
                return;
            }

            Funcionario FuncionarioAntigo = null;

            while (FuncionarioAntigo == null)
            {
                FuncionarioAntigo = SelecionarFuncionarioPorId();
                ApresentarMensagem("Id não encontrado!", ConsoleColor.Red);
            }

            Funcionario funcionarioNovo = ObterFuncionario();

            _repositorioFuncionario.Editar(FuncionarioAntigo, funcionarioNovo);

            ApresentarMensagem("Funcionario editado com sucesso!", ConsoleColor.Green);

            Console.ReadKey();
        }

        public void ExcluirFuncionario()
        {
            Console.Clear();

            Console.WriteLine("Excluindo funcionario...");
            Console.WriteLine();

            bool temFuncionario = VisualizarFuncionarios();

            if (temFuncionario == false)
            {
                VoltarAoMenu();
                return;
            }

            Funcionario funcionarioParaExcluir;

            while (true)
            {
                funcionarioParaExcluir = SelecionarFuncionarioPorId();

                if (funcionarioParaExcluir == null)
                {
                    ApresentarMensagem("Id não encontrado!", ConsoleColor.Red);
                }

                else
                    break;
            }

            _repositorioFuncionario.Excluir(funcionarioParaExcluir);

            ApresentarMensagem("Funcionario excluído com sucesso!", ConsoleColor.Green);

            Console.ReadKey();
        }

        public bool VisualizarFuncionarios()
        {
            List<Funcionario> listaFuncionarios = _repositorioFuncionario.SelecionarTodos();

            if (listaFuncionarios.Count == 0)
            {
                ApresentarMensagem("Nenhum funcionário cadastrado.", ConsoleColor.Red);
                return false;
            }

            Console.WriteLine("Visualizando funcionários...");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-3} | {1,-35} | {2,-14} | {3,-18}", "ID", "Nome", "CPF", "Telefone");
            Console.WriteLine("-----------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Funcionario f in listaFuncionarios)
            {
                Console.WriteLine("{0,-3} | {1,-35} | {2,-14} | {3,-18}", f.Id, f.Nome, f.Cpf, f.Telefone);
            }

            return true;
        }

        private Funcionario SelecionarFuncionarioPorId()
        {
            int idSelecionado = 0;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Digite o ID do funcionário: ");

                try
                {
                    idSelecionado = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    ApresentarMensagem("Valor digitado inválido. Por favor, digite um número inteiro válido.", ConsoleColor.Red);
                }
                catch (OverflowException)
                {
                    Console.WriteLine();
                    ApresentarMensagem("Valor digitado é grande demais. Por favor, digite um número inteiro válido.", ConsoleColor.Red);
                }
            }

            List<Funcionario> listaFuncionarios = _repositorioFuncionario.SelecionarTodos();

            Funcionario funcionario = listaFuncionarios.Find(f => f.Id == idSelecionado);

            return funcionario;
        }

        private Funcionario ObterFuncionario()
        {
            Console.Clear();

            Console.WriteLine("------ Cadastrar Funcionario ------");
            Console.WriteLine();

            Console.Write(">> Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write(">> Digite o CPF: ");
            string cpf = Console.ReadLine();

            Console.Write(">> Digite o login: ");
            string login = Console.ReadLine();

            Console.Write(">> Digite o senha: ");
            string senha = Console.ReadLine();

            Console.Write(">> Digite o telefone: ");
            string telefone = Console.ReadLine();

            Funcionario funcionario = new(nome, cpf, login, senha, telefone, _telaEndereco.ObterEndereco());

            return funcionario;
        }
    }
}
