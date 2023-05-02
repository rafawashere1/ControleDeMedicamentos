using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : TelaBase<Paciente>
    {
        private readonly TelaEndereco _telaEndereco;

        public TelaPaciente(RepositorioPaciente repositorioPaciente, TelaEndereco telaEndereco) : base(repositorioPaciente)
        {
            _telaEndereco = telaEndereco;
            nomeEntidade = "Paciente";
            sufixo = "s";
        }

        protected override void MostrarTabela(List<Paciente> registros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Cartão SUS");

            Console.WriteLine("--------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Paciente paciente in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", paciente.Id, paciente.Nome, paciente.CartaoSus);
            }
        }

        protected override Paciente ObterRegistro()
        {
            Endereco endereco = ObterEndereco();

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o número do cartão do SUS: ");
            string cartaoSUS = Console.ReadLine();

            Console.Write("Digite o número do telefone: ");
            string telefone = Console.ReadLine();

            return new Paciente(nome, cartaoSUS, telefone, endereco);
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
