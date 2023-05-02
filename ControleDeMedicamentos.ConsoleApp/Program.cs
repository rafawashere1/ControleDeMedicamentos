using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoEntrada;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoSaida;

namespace ControleDeMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioPaciente repositorioPaciente = new();
            RepositorioFuncionario repositorioFuncionario = new();
            RepositorioFornecedor repositorioFornecedor = new();
            RepositorioMedicamento repositorioMedicamento = new();
            RepositorioEndereco repositorioEndereco = new();
            RepositorioRequisicaoEntrada repositorioRequisicaoEntrada = new();
            RepositorioRequisicaoSaida repositorioRequisicaoSaida = new();

            CadastrarRegistros(repositorioFuncionario, repositorioFornecedor, 
                repositorioMedicamento, repositorioPaciente, repositorioEndereco, repositorioRequisicaoEntrada, repositorioRequisicaoSaida);

            TelaEndereco telaEndereco = new(repositorioEndereco);
            TelaPaciente telaPaciente = new(repositorioPaciente, telaEndereco);
            TelaFuncionario telaFuncionario = new(repositorioFuncionario, telaEndereco);
            TelaFornecedor telaFornecedor = new(repositorioFornecedor, telaEndereco);
            TelaMedicamento telaMedicamento = new(repositorioMedicamento, telaFornecedor, repositorioFornecedor);
            TelaRequisicaoEntrada telaRequisicaoEntrada = new(repositorioRequisicaoEntrada, repositorioFuncionario, repositorioMedicamento, telaFuncionario, telaMedicamento);
            TelaRequisicaoSaida telaRequisicaoSaida = new(repositorioRequisicaoSaida, repositorioPaciente, telaPaciente, repositorioFuncionario, telaFuncionario, repositorioMedicamento, telaMedicamento);

            while (true)
            {
                string opcao = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "6" && opcao != "S")
                {
                    Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                    Utils.VoltarAoMenu();
                }

                switch (opcao)
                {
                    case "1":

                        string opcaoPaciente = telaPaciente.ApresentarMenu();

                        if (opcaoPaciente != "1" && opcaoPaciente != "2" && opcaoPaciente != "3" && opcaoPaciente != "4" && opcaoPaciente != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoPaciente == "1")
                            telaPaciente.InserirNovoRegistro();

                        else if (opcaoPaciente == "2")
                            telaPaciente.EditarRegistro();

                        else if (opcaoPaciente == "3")
                            telaPaciente.ExcluirRegistro();

                        else if (opcaoPaciente == "4")
                        {
                            Console.Clear();

                            telaPaciente.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if (opcaoPaciente == "S")
                            continue;

                        break;

                    case "2":

                        string opcaoFuncionario = telaFuncionario.ApresentarMenu();

                        if (opcaoFuncionario != "1" && opcaoFuncionario != "2" && opcaoFuncionario != "3" && opcaoFuncionario != "4" && opcaoFuncionario != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoFuncionario == "1")
                            telaFuncionario.InserirNovoRegistro();

                        else if (opcaoFuncionario == "2")
                            telaFuncionario.EditarRegistro();

                        else if (opcaoFuncionario == "3")
                            telaFuncionario.ExcluirRegistro();

                        else if (opcaoFuncionario == "4")
                        {
                            Console.Clear();

                            telaFuncionario.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if (opcaoFuncionario == "S")
                            continue;

                        break;

                    case "3":

                        string opcaoMedicamento = telaMedicamento.ApresentarMenu();

                        if (opcaoMedicamento != "1" && opcaoMedicamento != "2" && opcaoMedicamento != "3" && opcaoMedicamento != "4" && opcaoMedicamento != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoMedicamento == "1")
                            telaMedicamento.InserirNovoRegistro();

                        else if (opcaoMedicamento == "2")
                            telaMedicamento.EditarRegistro();

                        else if (opcaoMedicamento == "3")
                            telaMedicamento.ExcluirRegistro();

                        else if (opcaoMedicamento == "4")
                        {
                            Console.Clear();

                            telaMedicamento.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if(opcaoMedicamento == "5")
                            telaMedicamento.VisualizarMedicamentosMaisRetirados();

                        else if (opcaoMedicamento == "6")
                            telaMedicamento.VisualizarMedicamentosEmFalta();

                        else if (opcaoMedicamento == "S")
                            continue;

                        break;

                    case "4":

                        string opcaoFornecedor = telaFornecedor.ApresentarMenu();

                        if (opcaoFornecedor != "1" && opcaoFornecedor != "2" && opcaoFornecedor != "3" && opcaoFornecedor != "4" && opcaoFornecedor != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoFornecedor == "1")
                            telaFornecedor.InserirNovoRegistro();

                        else if (opcaoFornecedor == "2")
                            telaFornecedor.EditarRegistro();

                        else if (opcaoFornecedor == "3")
                            telaFornecedor.ExcluirRegistro();

                        else if (opcaoFornecedor == "4")
                        {
                            Console.Clear();

                            telaMedicamento.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if (opcaoFornecedor == "S")
                            continue;
                        break;

                    case "5":

                        string opcaoRequisicaoEntrada = telaRequisicaoEntrada.ApresentarMenu();

                        if (opcaoRequisicaoEntrada != "1" && opcaoRequisicaoEntrada != "2" && opcaoRequisicaoEntrada != "3" && opcaoRequisicaoEntrada != "4" && opcaoRequisicaoEntrada != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoRequisicaoEntrada == "1")
                            telaRequisicaoEntrada.InserirNovoRegistro();

                        else if (opcaoRequisicaoEntrada == "2")
                            telaRequisicaoEntrada.EditarRegistro();

                        else if (opcaoRequisicaoEntrada == "3")
                            telaRequisicaoEntrada.ExcluirRegistro();

                        else if (opcaoRequisicaoEntrada == "4")
                        {
                            Console.Clear();

                            telaRequisicaoEntrada.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if (opcaoRequisicaoEntrada == "S")
                            continue;
                        break;
                    case "6":

                        string opcaoRequisicaoSaida = telaRequisicaoSaida.ApresentarMenu();

                        if (opcaoRequisicaoSaida != "1" && opcaoRequisicaoSaida != "2" && opcaoRequisicaoSaida != "3" && opcaoRequisicaoSaida != "4" && opcaoRequisicaoSaida != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoRequisicaoSaida == "1")
                            telaRequisicaoSaida.InserirNovoRegistro();

                        else if (opcaoRequisicaoSaida == "2")
                            telaRequisicaoSaida.EditarRegistro();

                        else if (opcaoRequisicaoSaida == "3")
                            telaRequisicaoSaida.ExcluirRegistro();

                        else if (opcaoRequisicaoSaida == "4")
                        {
                            Console.Clear();

                            telaRequisicaoSaida.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if (opcaoRequisicaoSaida == "S")
                            continue;

                        break;
                    case "S":
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }

        private static void CadastrarRegistros(
            RepositorioFuncionario repositorioFuncionario,
            RepositorioFornecedor repositorioFornecedor,
            RepositorioMedicamento repositorioMedicamento,
            RepositorioPaciente repositorioPaciente,
            RepositorioEndereco repositorioEndereco,
            RepositorioRequisicaoEntrada repositorioRequisicaoEntrada,
            RepositorioRequisicaoSaida repositorioRequisicaoSaida)
        {
            Endereco endereco = new("R. Itapetininga", "347", "Gravataí", "RS", "Brasil");

            repositorioEndereco.Inserir(endereco);

            Funcionario funcionario1 = new("Rafael Casa Nova dos Santos", "admin", "admin", "(51) 9 9661-6240", endereco);
            Funcionario funcionario2 = new("Agatha Sates Morais", "admin", "admin", "(51) 9 9661-6240", endereco);

            repositorioFuncionario.Inserir(funcionario1);

            Fornecedor fornecedor1 = new("Rafael Santos", "(51) 9 9661-6240", "rafael@fornecedor.com", endereco);
            Fornecedor fornecedor2 = new("Agatha Sates", "(51) 9 9661-6240", "agatha@fornecedor.com", endereco);

            repositorioFornecedor.Inserir(fornecedor1);
            repositorioFornecedor.Inserir(fornecedor2);

            Medicamento medicamento1 = new Medicamento("Gliclazida", "Remédio p/ Diabetes", "321-987", new DateTime(2024, 01, 01), fornecedor1);
            Medicamento medicamento2 = new Medicamento("Bisoprolol", "Remédio p/ Coração", "321-987", new DateTime(2024, 01, 01), fornecedor1);

            repositorioMedicamento.Inserir(medicamento1);
            repositorioMedicamento.Inserir(medicamento2);

            Paciente paciente1 = new("Rafael Santos", "701 2000 7660 7217", "(51) 9 9661-6240", endereco);

            repositorioPaciente.Inserir(paciente1);

            RequisicaoEntrada requisicaoEntrada1 = new RequisicaoEntrada(medicamento1, 20, DateTime.Now, funcionario1);
            RequisicaoEntrada requisicaoEntrada2 = new RequisicaoEntrada(medicamento2, 20, DateTime.Now, funcionario2);

            repositorioRequisicaoEntrada.Inserir(requisicaoEntrada1);
            repositorioRequisicaoEntrada.Inserir(requisicaoEntrada2);

        }
    }
}
