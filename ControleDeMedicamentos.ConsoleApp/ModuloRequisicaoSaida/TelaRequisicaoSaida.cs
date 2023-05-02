using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoSaida
{
    public class TelaRequisicaoSaida : TelaBase<RequisicaoSaida>
    {

        private readonly RepositorioPaciente _repositorioPaciente;
        private readonly TelaPaciente _telaPaciente;

        private readonly RepositorioFuncionario _repositorioFuncionario;
        private readonly TelaFuncionario _telaFuncionario;

        private readonly RepositorioMedicamento _repositorioMedicamento;
        private readonly TelaMedicamento _telaMedicamento;

        public TelaRequisicaoSaida(RepositorioRequisicaoSaida repositorioRequisicaoSaida, RepositorioPaciente repositorioPaciente, TelaPaciente telaPaciente,
            RepositorioFuncionario repositorioFuncionario, TelaFuncionario telaFuncionario, RepositorioMedicamento repositorioMedicamento, TelaMedicamento telaMedicamento)
        : base(repositorioRequisicaoSaida)
        {
            _repositorioPaciente = repositorioPaciente;
            _telaPaciente = telaPaciente;
            _repositorioFuncionario = repositorioFuncionario;
            _telaFuncionario = telaFuncionario;
            _repositorioMedicamento = repositorioMedicamento;
            _telaMedicamento = telaMedicamento;

            nomeEntidade = "Requisição de Saída";
        }

        public override void InserirNovoRegistro()
        {
            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo}");
            Console.WriteLine();
            Console.WriteLine("Inserindo um novo registro...");

            bool temFuncionarios = _repositorioFuncionario.TemRegistro();

            if (temFuncionarios == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um funcionário para cadastrar requisições de saída", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            bool temMedicamentos = _repositorioMedicamento.TemRegistro();

            if (temMedicamentos == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um medicamento para cadastrar requisições de saída", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            bool temPacientes = _repositorioPaciente.TemRegistro();

            if (temPacientes == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um paciente para cadastrar requisições de saída", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            RequisicaoSaida registro = (RequisicaoSaida)ObterRegistro();

            if (TemErrosDeValidacao(registro))
            {
                return;
            }

            registro.RegistrarSaida();

            repositorioBase.Inserir(registro);

            Utils.MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green, TipoMensagem.READKEY);
        }

        public override void EditarRegistro()
        {
            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo}");
            Console.WriteLine();
            Console.WriteLine("Editando um registro já cadastrado...");

            bool temFuncionarios = _repositorioFuncionario.TemRegistro();

            if (temFuncionarios == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um funcionário para cadastrar requisições de saída", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            bool temMedicamentos = _repositorioMedicamento.TemRegistro();

            if (temMedicamentos == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um medicamento para cadastrar requisições de saída", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            bool temPacientes = _repositorioPaciente.TemRegistro();

            if (temPacientes == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um paciente para cadastrar requisições de saída", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            VisualizarRegistros(false);

            Console.WriteLine();

            RequisicaoSaida requisicaoSaida = EncontrarRegistro("Digite o id do registro: ");

            RequisicaoSaida requisicaoSaidaAtualizado = (RequisicaoSaida)ObterRegistro();

            if (TemErrosDeValidacao(requisicaoSaidaAtualizado))
            {
                return;
            }

            requisicaoSaida.DesfazerRegistroSaida();

            requisicaoSaidaAtualizado.RegistrarSaida();

            repositorioBase.Editar(requisicaoSaida, requisicaoSaidaAtualizado);

            Utils.MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green, TipoMensagem.READKEY);
        }

        public override void ExcluirRegistro()
        {
            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo}");
            Console.WriteLine();
            Console.WriteLine("Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            RequisicaoSaida requisicaoSaida = EncontrarRegistro("Digite o id do registro: ");

            requisicaoSaida.DesfazerRegistroSaida();

            repositorioBase.Excluir(requisicaoSaida);

            Utils.MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green, TipoMensagem.READKEY);
        }

        protected override void MostrarTabela(List<RequisicaoSaida> registros)
        {
            const string FORMATO_TABELA = "{0, -10} | {1, -10} | {2, -20} | {3, -20} | {4, -20} | {5, -20}";

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(FORMATO_TABELA, "Id", "Data", "Medicamento", "Fonecedor", "Paciente", "Quantidade");

            Console.WriteLine("--------------------------------------------------------------------");

            Console.ResetColor();

            foreach (RequisicaoSaida requisicaoSaida in registros)
            {
                Console.WriteLine(FORMATO_TABELA,
                    requisicaoSaida.Id,
                    requisicaoSaida.Data.ToShortDateString(),
                    requisicaoSaida.Medicamento.Nome,
                    requisicaoSaida.Medicamento.Fornecedor.Nome,
                    requisicaoSaida.Paciente.Nome,
                    requisicaoSaida.Quantidade);
            }
        }

        protected override RequisicaoSaida ObterRegistro()
        {
            Medicamento medicamento = ObterMedicamento();

            Funcionario funcionario = ObterFuncionario();

            Paciente paciente = ObterPaciente();

            Console.Write("Digite a quantidade de caixas: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            return new RequisicaoSaida(medicamento, quantidade, data, funcionario, paciente);
        }

        private Paciente ObterPaciente()
        {
            _telaPaciente.VisualizarRegistros(false);

            Paciente paciente = _telaPaciente.EncontrarRegistro("Digite o id do paciente: ");

            Console.WriteLine();

            return paciente;
        }

        private Funcionario ObterFuncionario()
        {
            _telaFuncionario.VisualizarRegistros(false);

            Funcionario funcionario = _telaFuncionario.EncontrarRegistro("Digite o id do funcionário: ");

            Console.WriteLine();

            return funcionario;
        }

        private Medicamento ObterMedicamento()
        {
            _telaMedicamento.VisualizarRegistros(false);

            Medicamento medicamento = _telaMedicamento.EncontrarRegistro("Digite o id do medicamento: ");

            Console.WriteLine();

            return medicamento;
        }
    }
}
