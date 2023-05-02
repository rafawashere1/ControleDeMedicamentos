using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoSaida
{
    public class RequisicaoSaida : EntidadeBase
    {
        public Medicamento Medicamento { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public Funcionario Funcionario { get; set; }
        public Paciente Paciente { get; set; }

        public RequisicaoSaida(Medicamento medicamento, int quantidade, DateTime data, Funcionario funcionario, Paciente paciente)
        {
            Medicamento = medicamento;
            Data = data;
            Funcionario = funcionario;
            Paciente = paciente;
            Quantidade = quantidade;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            RequisicaoSaida requisicaoSaidaAtualizada = (RequisicaoSaida)registroAtualizado;

            Medicamento = requisicaoSaidaAtualizada.Medicamento;
            Quantidade = requisicaoSaidaAtualizada.Quantidade;
            Data = requisicaoSaidaAtualizada.Data;
            Funcionario = requisicaoSaidaAtualizada.Funcionario;
            Paciente = requisicaoSaidaAtualizada.Paciente;
        }

        public void DesfazerRegistroSaida()
        {
            Medicamento.AdicionarQuantidade(Quantidade);
        }

        public void RegistrarSaida()
        {
            Medicamento.RemoverQuantidade(Quantidade);
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (Medicamento == null)
                erros.Add("O campo \"medicamento\" é obrigatório");

            if (Funcionario == null)
                erros.Add("O campo \"funcionário\" é obrigatório");

            if (Paciente == null)
                erros.Add("O campo \"paciente\" é obrigatório");

            if (Data < DateTime.Now.Date)
                erros.Add("O campo \"data\" deve ser maior que a data atual");

            if (Quantidade < 0)
                erros.Add("O campo \"quantidade\" deve ser maior que 0");

            if (Medicamento != null && Quantidade > Medicamento.Quantidade)
                erros.Add("O campo \"quantidade requisitada\" excedeu a quantidade em estoque deste medicamento");

            return erros;
        }
    }
}
