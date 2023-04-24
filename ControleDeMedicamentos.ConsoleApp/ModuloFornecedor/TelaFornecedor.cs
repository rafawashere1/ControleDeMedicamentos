using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    internal class TelaFornecedor : Tela
    {
        private readonly RepositorioFornecedor _repositorioFornecedor;
        private readonly TelaEndereco _telaEndereco;

        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor, TelaEndereco telaEndereco)
        {
            _repositorioFornecedor = repositorioFornecedor;
            _telaEndereco = telaEndereco;
        }

        public string ApresentarMenuFornecedor()
        {
            Console.Clear();

            Console.WriteLine("------ Controle de Fornecedor ------");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar fornecedor");
            Console.WriteLine("[2] Editar fornecedor");
            Console.WriteLine("[3] Excluir fornecedor");
            Console.WriteLine("[4] Visualizar fornecedores");
            Console.WriteLine();
            Console.WriteLine("[S] Voltar ao menu principal");

            Console.WriteLine();
            Console.Write("Digite uma opção: ");

            string opcao = Console.ReadLine().ToUpper();

            return opcao;
        }

        public void InserirFornecedor()
        {
            Fornecedor NovoFornecedor = ObterFornecedor();

            _repositorioFornecedor.Inserir(NovoFornecedor);
        }

        public void EditarFornecedor()
        {
            Console.Clear();

            Console.WriteLine("Editando fornecedor...");
            Console.WriteLine();

            bool temFornecedor = VisualizarFornecedor();

            if (temFornecedor == false)
            {
                VoltarAoMenu();
                return;
            }

            Fornecedor fornecedorAntigo = null;

            while (fornecedorAntigo == null)
            {
                fornecedorAntigo = SelecionarFornecedorPorId();
                ApresentarMensagem("Id não encontrado!", ConsoleColor.Red);
            }

            Fornecedor fornecedorNovo = ObterFornecedor();

            _repositorioFornecedor.Editar(fornecedorAntigo, fornecedorNovo);

            ApresentarMensagem("Fornecedor editado com sucesso!", ConsoleColor.Green);

            Console.ReadKey();
        }

        public void ExcluirFornecedor()
        {
            Console.Clear();

            Console.WriteLine("Excluindo fornecedor...");
            Console.WriteLine();

            bool temFornecedor = VisualizarFornecedor();

            if (temFornecedor == false)
            {
                VoltarAoMenu();
                return;
            }

            Fornecedor fornecedorParaExcluir;

            while (true)
            {
                fornecedorParaExcluir = SelecionarFornecedorPorId();

                if (fornecedorParaExcluir == null)
                {
                    ApresentarMensagem("Id não encontrado!", ConsoleColor.Red);
                }

                else
                    break;
            }

            _repositorioFornecedor.Excluir(fornecedorParaExcluir);

            ApresentarMensagem("Fornecedor excluído com sucesso!", ConsoleColor.Green);

            Console.ReadKey();
        }

        public bool VisualizarFornecedor()
        {
            List<Fornecedor> listaFornecedores = _repositorioFornecedor.SelecionarTodos();

            if (listaFornecedores.Count == 0)
            {
                ApresentarMensagem("Nenhum fornecedor cadastrado.", ConsoleColor.Red);
                return false;
            }

            Console.WriteLine("Visualizando fornecedores...");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-3} | {1,-35} | {2,-18} | {3,-18} | {4,-18}", "ID", "Nome", "CNPJ", "Telefone", "E-mail");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Fornecedor f in listaFornecedores)
            {
                Console.WriteLine("{0,-3} | {1,-35} | {2,-14} | {3,-18} | {4,-18}", f.Id, f.Nome, f.Cnpj, f.Telefone, f.Email);
            }

            return true;
        }

        private Fornecedor SelecionarFornecedorPorId()
        {
            int idSelecionado = 0;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Digite o ID do fornecedor: ");

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

            List<Fornecedor> listaFornecedores = _repositorioFornecedor.SelecionarTodos();

            Fornecedor fornecedor = listaFornecedores.Find(f => f.Id == idSelecionado);

            return fornecedor;
        }

        internal Fornecedor ObterFornecedor()
        {
            Console.Clear();

            Console.WriteLine("------ Cadastrar Fornecedor ------");
            Console.WriteLine();

            Console.Write(">> Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write(">> Digite o CNPJ: ");
            string cnpj = Console.ReadLine();

            Console.Write(">> Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write(">> Digite o e-mail: ");
            string email = Console.ReadLine();

            Fornecedor fornecedor = new(nome, cnpj, telefone, email, _telaEndereco.ObterEndereco());

            return fornecedor;
        }
    }
}
