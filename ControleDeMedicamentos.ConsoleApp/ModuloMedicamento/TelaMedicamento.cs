using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : TelaBase<Medicamento>
    {
        private readonly RepositorioMedicamento _repositorioMedicamento;
        private readonly TelaFornecedor _telaFornecedor;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, TelaFornecedor telaFornecedor, RepositorioFornecedor repositorioFornecedor) : base(repositorioMedicamento)
        {

            _repositorioMedicamento = repositorioMedicamento;
            _telaFornecedor = telaFornecedor;
            nomeEntidade = "Medicamento";
            sufixo = "s";
        }

        public override void InserirNovoRegistro()
        {
            bool temRegistros = repositorioBase.TemRegistro();

            if (temRegistros == false)
            {
                Utils.MostrarMensagem("Cadastre ao menos um fornecedor para cadastrar medicamentos", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            base.InserirNovoRegistro();
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Medicamentos");
            Console.WriteLine();

            Console.WriteLine("[1] Inserir Medicamento");
            Console.WriteLine("[2] Editar Medicamentos");
            Console.WriteLine("[3] Excluir Medicamentos");
            Console.WriteLine("[4] Visualizar Medicamentos");
            Console.WriteLine("[5] Visualizar Medicamentos Mais Retirados");
            Console.WriteLine("[6] Visualizar Medicamentos em Falta\n");

            Console.WriteLine("[S] Voltar ao menu principal");

            Console.WriteLine();
            Console.Write("Digite uma opção: ");

            return Console.ReadLine().ToUpper();
        }

        protected override void MostrarTabela(List<Medicamento> registros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}", "Id", "Nome", "Fornecedor", "Quantidade", "Qtd Retiradas");

            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Medicamento medicamento in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                    medicamento.Id, medicamento.Nome, medicamento.Fornecedor.Nome, medicamento.Quantidade, medicamento.QuantidadeRequisicoesSaida);
            }
        }

        protected override Medicamento ObterRegistro()
        {
            Fornecedor fornecedor = ObterFornecedor();

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o lote: ");
            string lote = Console.ReadLine();

            Console.Write("Digite a data de validade: ");

            DateTime dataValidade = DateTime.MinValue;

            bool dataInvalida;

            do
            {
                dataInvalida = false;

                try
                {
                    dataValidade = Convert.ToDateTime(Console.ReadLine());
                }
                catch (FormatException)
                {
                    dataInvalida = true;
                    Utils.MostrarMensagem("Formato da data está inválido. Ex: 12/12/2000", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                }
                catch (ArgumentNullException)
                {
                    dataInvalida = true;
                    Utils.MostrarMensagem("Informe uma data. Ex: 12/12/2000", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                }

            } while (dataInvalida);

            return new Medicamento(nome, descricao, lote, dataValidade, fornecedor);
        }

        public void VisualizarMedicamentosMaisRetirados()
        {
            Console.WriteLine("Cadastro de Medicamentos");
            Console.WriteLine();
            Console.WriteLine("Visualizando medicamentos mais Retirados...");

            List<Medicamento> medicamentosMaisRetirados = _repositorioMedicamento.SelecionarMedicamentosMaisRetirados();

            if (medicamentosMaisRetirados.Count == 0)
            {
                Utils.MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            MostrarTabela(medicamentosMaisRetirados);
        }

        public void VisualizarMedicamentosEmFalta()
        {
            Console.WriteLine("Cadastro de Medicamentos");
            Console.WriteLine();
            Console.WriteLine("Visualizando medicamentos em falta...");

            List<Medicamento> medicamentosMaisRetirados = _repositorioMedicamento.SelecionarMedicamentosEmFalta();

            if (medicamentosMaisRetirados.Count == 0)
            {
                Utils.MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            MostrarTabela(medicamentosMaisRetirados);
        }

        private Fornecedor ObterFornecedor()
        {
            _telaFornecedor.VisualizarRegistros(false);

            Fornecedor fornecedor = _telaFornecedor.EncontrarRegistro("Digite o id do fornecedor: ");

            Console.WriteLine();

            return fornecedor;
        }
    }
}