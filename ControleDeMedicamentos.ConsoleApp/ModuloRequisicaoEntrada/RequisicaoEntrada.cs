using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoEntrada
{
    public class RequisicaoEntrada : EntidadeBase
    {
        public Medicamento Medicamento { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public Funcionario Funcionario { get; set; }

        public RequisicaoEntrada(Medicamento medicamento, int quantidade, DateTime data, Funcionario funcionario)
        {
            Medicamento = medicamento;
            Quantidade = quantidade;
            Data = data;
            Funcionario = funcionario;

            Medicamento.AdicionarQuantidade(quantidade);
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            RequisicaoEntrada requisicaoEntradaAtualizada = (RequisicaoEntrada)registroAtualizado;

            Medicamento = requisicaoEntradaAtualizada.Medicamento;
            Quantidade = requisicaoEntradaAtualizada.Quantidade;
            Data = requisicaoEntradaAtualizada.Data;
            Funcionario = requisicaoEntradaAtualizada.Funcionario;
        }

        public void DesfazerRegistroEntrada()
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

            if (Data < DateTime.Now.Date)
                erros.Add("O campo \"data\" deve ser maior que a data atual");

            if (Quantidade < 0)
                erros.Add("O campo \"quantidade\" deve ser maior que 0");

            return erros;
        }
    }
}
