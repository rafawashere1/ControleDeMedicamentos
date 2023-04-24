using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RepositorioEndereco repositorioEndereco = new();
            RepositorioPaciente repositorioPaciente = new(repositorioEndereco);
            RepositorioFuncionario repositorioFuncionario = new(repositorioEndereco);
            RepositorioFornecedor repositorioFornecedor = new(repositorioEndereco);
            RepositorioMedicamento repositorioMedicamento = new(repositorioFornecedor);

            TelaEndereco telaEndereco = new();
            TelaPaciente telaPaciente = new(repositorioPaciente, telaEndereco);
            TelaFuncionario telaFuncionario = new(repositorioFuncionario, telaEndereco);
            TelaFornecedor telaFornecedor = new(repositorioFornecedor, telaEndereco);
            TelaMedicamento telaMedicamento = new(repositorioMedicamento, telaFornecedor);

            repositorioEndereco.PopularListaEndereco();
            repositorioPaciente.PopularListaPaciente();
            repositorioFuncionario.PopularListaFuncionario();
            repositorioFornecedor.PopularListaFornecedor();
            repositorioMedicamento.PopularListaMedicamento();

            while (true)
            {
                string opcao = ApresentarMenuPrincipal();

                if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "6" && opcao != "S")
                {
                    Tela.ApresentarMensagem("Opção inválida!", ConsoleColor.Red);
                    Tela.VoltarAoMenu();
                }

                switch (opcao)
                {
                    case "1":
                        
                        string opcaoPaciente = telaPaciente.ApresentarMenuPaciente();

                        if (opcaoPaciente != "1" && opcaoPaciente != "2" && opcaoPaciente != "3" && opcaoPaciente != "4" && opcaoPaciente != "S")
                        {
                            Tela.ApresentarMensagem("Opção inválida!", ConsoleColor.Red);
                            Tela.VoltarAoMenu();
                        }

                        if (opcaoPaciente == "1")
                            telaPaciente.InserirPaciente();

                        else if (opcaoPaciente == "2")
                            telaPaciente.EditarPaciente();

                        else if (opcaoPaciente == "3")
                            telaPaciente.ExcluirPaciente();

                        else if (opcaoPaciente == "4")
                        {
                            Console.Clear();

                            telaPaciente.VisualizarPacientes();

                            Tela.VoltarAoMenu();
                        }

                        else if (opcaoPaciente == "S")
                            continue;

                        break;
                    case "2":

                        string opcaoFuncionario = telaFuncionario.ApresentarMenuFuncionario();

                        if (opcaoFuncionario != "1" && opcaoFuncionario != "2" && opcaoFuncionario != "3" && opcaoFuncionario != "4" && opcaoFuncionario != "S")
                        {
                            Tela.ApresentarMensagem("Opção inválida!", ConsoleColor.Red);
                            Tela.VoltarAoMenu();
                        }

                        if (opcaoFuncionario == "1")
                            telaFuncionario.InserirFuncionario();

                        else if (opcaoFuncionario == "2")
                            telaFuncionario.EditarFuncionario();

                        else if (opcaoFuncionario == "3")
                            telaFuncionario.ExcluirFuncionario();

                        else if (opcaoFuncionario == "4")
                        {
                            Console.Clear();

                            telaFuncionario.VisualizarFuncionarios();

                            Tela.VoltarAoMenu();
                        }

                        else if (opcaoFuncionario == "S")
                            continue;
                        break;
                    case "3":

                        string opcaoMedicamento = telaMedicamento.ApresentarMenuMedicamento();

                        if (opcaoMedicamento != "1" && opcaoMedicamento != "2" && opcaoMedicamento != "3" && opcaoMedicamento != "4" && opcaoMedicamento != "S")
                        {
                            Tela.ApresentarMensagem("Opção inválida!", ConsoleColor.Red);
                            Tela.VoltarAoMenu();
                        }

                        if (opcaoMedicamento == "1")
                            telaMedicamento.InserirMedicamento();

                        else if (opcaoMedicamento == "2")
                            telaMedicamento.EditarMedicamento();

                        else if (opcaoMedicamento == "3")
                            telaMedicamento.ExcluirMedicamento();

                        else if (opcaoMedicamento == "4")
                        {
                            Console.Clear();

                            telaMedicamento.VisualizarMedicamentos();

                            Tela.VoltarAoMenu();
                        }

                        else if (opcaoMedicamento == "S")
                            continue;

                        break;
                    case "4":

                        string opcaoFornecedor = telaFornecedor.ApresentarMenuFornecedor();

                        if (opcaoFornecedor != "1" && opcaoFornecedor != "2" && opcaoFornecedor != "3" && opcaoFornecedor != "4" && opcaoFornecedor != "S")
                        {
                            Tela.ApresentarMensagem("Opção inválida!", ConsoleColor.Red);
                            Tela.VoltarAoMenu();
                        }

                        if (opcaoFornecedor == "1")
                            telaFornecedor.InserirFornecedor();

                        else if (opcaoFornecedor == "2")
                            telaFornecedor.EditarFornecedor();

                        else if (opcaoFornecedor == "3")
                            telaFornecedor.ExcluirFornecedor();

                        else if (opcaoFornecedor == "4")
                        {
                            Console.Clear();

                            telaFornecedor.VisualizarFornecedor();

                            Tela.VoltarAoMenu();
                        }

                        else if (opcaoFornecedor == "S")
                            continue;

                        break;
                    case "S": Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }

        public static string ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("------ Controle de Medicamentos ------");
            Console.WriteLine();

            Console.WriteLine("[1] Menu de Paciente");
            Console.WriteLine("[2] Menu de Funcionario");
            Console.WriteLine("[3] Menu de Medicamento");
            Console.WriteLine("[4] Menu de Fornecedor");
            Console.WriteLine();
            Console.WriteLine("[S] Fechar o programa");

            Console.WriteLine();

            Console.Write("Digite uma opcão: ");

            string opcao = Console.ReadLine().ToUpper();

            return opcao;
        }
    }
}