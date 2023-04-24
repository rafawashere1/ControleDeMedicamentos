using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    internal class TelaPaciente : Tela
    {
        private readonly RepositorioPaciente _repositorioPaciente;
        private readonly TelaEndereco _telaEndereco;

        public TelaPaciente(RepositorioPaciente repositorioPaciente, TelaEndereco telaEndereco)
        {
            _repositorioPaciente = repositorioPaciente;
            _telaEndereco = telaEndereco;   

        }

        public string ApresentarMenuPaciente()
        {
            Console.Clear();

            Console.WriteLine("------ Controle de Paciente ------");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar paciente");
            Console.WriteLine("[2] Editar paciente");
            Console.WriteLine("[3] Excluir paciente");
            Console.WriteLine("[4] Visualizar pacientes");
            Console.WriteLine();
            Console.WriteLine("[S] Voltar ao menu principal");

            Console.WriteLine();
            Console.Write("Digite uma opção: ");

            string opcao = Console.ReadLine().ToUpper();

            return opcao;
        }

        public void InserirPaciente()
        {
            Paciente NovoPaciente = ObterPaciente();

            _repositorioPaciente.Inserir(NovoPaciente);
        }

        public void EditarPaciente()
        {
            Console.Clear();

            Console.WriteLine("Editando paciente...");
            Console.WriteLine();

            bool temPaciente = VisualizarPacientes();

            if (temPaciente == false)
            {
                VoltarAoMenu();
                return;
            }

            Paciente pacienteAntigo = null;

            while (pacienteAntigo == null)
            {
                pacienteAntigo = SelecionarPacientePorId();
                ApresentarMensagem("Id não encontrado!", ConsoleColor.Red);
            }

            Paciente pacienteNovo = ObterPaciente();

            _repositorioPaciente.Editar(pacienteAntigo, pacienteNovo);

            ApresentarMensagem("Paciente editado com sucesso!", ConsoleColor.Green);

            Console.ReadKey();
        }

        public void ExcluirPaciente()
        {
            Console.Clear();

            Console.WriteLine("Excluindo paciente...");
            Console.WriteLine();

            bool temPaciente = VisualizarPacientes();

            if (temPaciente == false)
            {
                VoltarAoMenu();
                return;
            }

            Paciente pacienteParaExcluir;

            while (true)
            {
                pacienteParaExcluir = SelecionarPacientePorId();

                if (pacienteParaExcluir == null)
                {
                    ApresentarMensagem("Id não encontrado!", ConsoleColor.Red);
                }

                else
                    break;
            }

            _repositorioPaciente.Excluir(pacienteParaExcluir);

            ApresentarMensagem("Paciente excluído com sucesso!", ConsoleColor.Green);

            Console.ReadKey();
        }

        public bool VisualizarPacientes()
        {
            List<Paciente> listaPacientes = _repositorioPaciente.SelecionarTodos();

            if (listaPacientes.Count == 0)
            {
                ApresentarMensagem("Nenhum paciente cadastrado.", ConsoleColor.Red);
                return false;
            }

            Console.WriteLine("Visualizando pacientes...");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-3} | {1,-35} | {2,-14} | {3,-18} | {4,-18}", "ID", "Nome", "CPF", "Cartão SUS", "Telefone");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Paciente p in listaPacientes)
            {
                Console.WriteLine("{0,-3} | {1,-35} | {2,-14} | {3,-18} | {4,-18}", p.Id, p.Nome, p.Cpf, p.CartaoSus, p.Telefone);
            }

            return true;
        }

        private Paciente SelecionarPacientePorId()
        {
            int idSelecionado = 0;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Digite o ID do paciente: ");

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

            List<Paciente> listaPacientes = _repositorioPaciente.SelecionarTodos();

            Paciente paciente = listaPacientes.Find(p => p.Id == idSelecionado);

            return paciente;
        }

        private Paciente ObterPaciente()
        {
            Console.Clear();

            Console.WriteLine("------ Cadastrar Paciente ------");
            Console.WriteLine();

            Console.Write(">> Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write(">> Digite o CPF: ");
            string cpf = Console.ReadLine();

            Console.Write(">> Digite o cartão do SUS: ");
            string cartaoSus = Console.ReadLine();

            Console.Write(">> Digite o telefone: ");
            string telefone = Console.ReadLine();

            Paciente paciente = new(nome, cpf, cartaoSus, telefone, _telaEndereco.ObterEndereco());

            return paciente;
        }
    }
}
