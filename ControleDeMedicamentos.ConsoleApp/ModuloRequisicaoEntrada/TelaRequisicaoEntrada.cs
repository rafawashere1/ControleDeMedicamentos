using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoEntrada
{
    public class TelaRequisicaoEntrada : TelaBase<RequisicaoEntrada>
    {
        private readonly RepositorioFuncionario _repositorioFuncionario;
        private readonly RepositorioMedicamento _repositorioMedicamento;

        private readonly TelaFuncionario _telaFuncionario;
        private readonly TelaMedicamento _telaMedicamento;

        public TelaRequisicaoEntrada(RepositorioRequisicaoEntrada repositorioRequisicaoEntrada, RepositorioFuncionario repositorioFuncionario, RepositorioMedicamento repositorioMedicamento,
            TelaFuncionario telaFuncionario, TelaMedicamento telaMedicamento) : base(repositorioRequisicaoEntrada)
        {

            _repositorioFuncionario = repositorioFuncionario;
            _repositorioMedicamento = repositorioMedicamento;
            _telaFuncionario = telaFuncionario;
            _telaMedicamento = telaMedicamento;

            nomeEntidade = "Requisições de Entrada";
        }

        public override void InserirNovoRegistro()
        {
            bool temFuncionarios = _repositorioFuncionario.TemRegistro();

            if (temFuncionarios == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um funcionário para cadastrar requisições de entrada", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            bool temMedicamentos = _repositorioMedicamento.TemRegistro();

            if (temMedicamentos == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um medicamento para cadastrar requisições de entrada", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            base.InserirNovoRegistro();
        }

        public override void EditarRegistro()
        {
            bool temFuncionarios = _repositorioFuncionario.TemRegistro();

            if (temFuncionarios == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um funcionário para cadastrar requisições de entrada", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            bool temMedicamentos = _repositorioMedicamento.TemRegistro();

            if (temMedicamentos == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um medicamento para cadastrar requisições de entrada", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo}");
            Console.WriteLine();
            Console.WriteLine("Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            RequisicaoEntrada requisicaoEntrada = EncontrarRegistro("Digite o id do registro: ");

            RequisicaoEntrada registroAtualizado = ObterRegistro();

            requisicaoEntrada.DesfazerRegistroEntrada();

            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();

                return;
            }

            repositorioBase.Editar(requisicaoEntrada.Id, registroAtualizado);

            Utils.MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green, TipoMensagem.READKEY);
        }

        public override void ExcluirRegistro()
        {
            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo}");
            Console.WriteLine();
            Console.WriteLine("Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            RequisicaoEntrada requisicaoEntrada = EncontrarRegistro("Digite o id do registro: ");

            requisicaoEntrada.DesfazerRegistroEntrada();

            repositorioBase.Excluir(requisicaoEntrada);

            Utils.MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green, TipoMensagem.READKEY);
        }

        protected override void MostrarTabela(List<RequisicaoEntrada> registros)
        {
            Console.WriteLine("{0, -10} | {1, -10} | {2, -20} | {3, -20}", "Id", "Data", "Medicamento", "Fonecedor", "Quantidade");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (RequisicaoEntrada requisicaoEntrada in registros)
            {
                Console.WriteLine("{0, -10} | {1, -10} | {2, -20} | {3, -20}",
                    requisicaoEntrada.Id,
                    requisicaoEntrada.Data.ToShortDateString(),
                    requisicaoEntrada.Medicamento.Nome,
                    requisicaoEntrada.Medicamento.Fornecedor.Nome,
                    requisicaoEntrada.Quantidade);
            }
        }

        protected override RequisicaoEntrada ObterRegistro()
        {
            Medicamento medicamento = ObterMedicamento();

            Funcionario funcionario = ObterFuncionario();

            Console.Write("Digite a quantidade de caixas: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            return new RequisicaoEntrada(medicamento, quantidade, data, funcionario);
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
