using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class TelaMedicamento : Tela
    {
        private readonly RepositorioMedicamento _repositorioMedicamento;

        private readonly TelaFornecedor _telaFornecedor;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, TelaFornecedor telaFornecedor)
        {
            _repositorioMedicamento = repositorioMedicamento;
            _telaFornecedor = telaFornecedor;
        }

        public string ApresentarMenuMedicamento()
        {
            Console.Clear();

            Console.WriteLine("------ Controle de Medicamento ------");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar medicamento");
            Console.WriteLine("[2] Editar medicamento");
            Console.WriteLine("[3] Excluir medicamento");
            Console.WriteLine("[4] Visualizar medicamento");
            Console.WriteLine();
            Console.WriteLine("[S] Voltar ao menu principal");

            Console.WriteLine();
            Console.Write("Digite uma opção: ");

            string opcao = Console.ReadLine().ToUpper();

            return opcao;
        }

        public void InserirMedicamento()
        {
            Medicamento NovoMedicamento = ObterMedicamento();

            _repositorioMedicamento.Inserir(NovoMedicamento);
        }

        public void EditarMedicamento()
        {
            Console.Clear();

            Console.WriteLine("Editando medicamento...");
            Console.WriteLine();

            bool temMedicamento = VisualizarMedicamentos();

            if (temMedicamento == false)
            {
                VoltarAoMenu();
                return;
            }

            Medicamento medicamentoAntigo = null;

            while (medicamentoAntigo == null)
            {
                medicamentoAntigo = SelecionarMedicamentoPorId();
                ApresentarMensagem("Id não encontrado!", ConsoleColor.Red);
            }

            Medicamento medicamentoNovo = ObterMedicamento();

            _repositorioMedicamento.Editar(medicamentoAntigo, medicamentoNovo);

            ApresentarMensagem("Medicamento editado com sucesso!", ConsoleColor.Green);

            Console.ReadKey();
        }

        public void ExcluirMedicamento()
        {
            Console.Clear();

            Console.WriteLine("Excluindo medicamento...");
            Console.WriteLine();

            bool temMedicamento = VisualizarMedicamentos();

            if (temMedicamento == false)
            {
                VoltarAoMenu();
                return;
            }

            Medicamento medicamentoParaExcluir;

            while (true)
            {
                medicamentoParaExcluir = SelecionarMedicamentoPorId();

                if (medicamentoParaExcluir == null)
                {
                    ApresentarMensagem("Id não encontrado!", ConsoleColor.Red);
                }

                else
                    break;
            }

            _repositorioMedicamento.Excluir(medicamentoParaExcluir);

            ApresentarMensagem("Medicamento excluído com sucesso!", ConsoleColor.Green);

            Console.ReadKey();
        }

        public bool VisualizarMedicamentos()
        {
            List<Medicamento> listaMedicamentos = _repositorioMedicamento.SelecionarTodos();

            if (listaMedicamentos.Count == 0)
            {
                ApresentarMensagem("Nenhum medicamento cadastrado.", ConsoleColor.Red);
                return false;
            }

            Console.WriteLine("Visualizando medicamentos...");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-3} | {1,-35} | {2,-14} | {3,-18}", "ID", "Nome", "Descrição", "Quantidade disponível");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Medicamento m in listaMedicamentos)
            {
                Console.WriteLine("{0,-3} | {1,-35} | {2,-14} | {3,-18}",
                    m.Id, m.Nome, m.Descricao, m.QuantidadeDisponivel == 0 ? "Em Falta" : m.QuantidadeDisponivel);
            }

            return true;
        }

        private Medicamento SelecionarMedicamentoPorId()
        {
            int idSelecionado = 0;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Digite o ID do medicamento: ");

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

            List<Medicamento> listaMedicamentos = _repositorioMedicamento.SelecionarTodos();

            Medicamento medicamento = listaMedicamentos.Find(m => m.Id == idSelecionado);

            return medicamento;
        }

        private Medicamento ObterMedicamento()
        {
            Console.Clear();

            Console.WriteLine("------ Cadastrar Medicamento ------");
            Console.WriteLine();

            Console.Write(">> Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write(">> Digite a descrição: ");
            string descricao = Console.ReadLine();

            Console.Write(">> Digite a quantidade: ");
            int quantidadeDisponivel = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamento = new(nome, descricao, quantidadeDisponivel, _telaFornecedor.ObterFornecedor());

            return medicamento;
        }
    }
}
