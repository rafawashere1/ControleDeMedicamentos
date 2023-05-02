using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lote { get; set; }
        public DateTime Validade { get; set; }
        public int Quantidade { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int QuantidadeRequisicoesSaida { get; set; }

        public Medicamento(string nome, string descricao, string lote, DateTime validade, Fornecedor fornecedor)
        {
            Nome = nome;
            Descricao = descricao;
            Lote = lote;
            Validade = validade;
            Fornecedor = fornecedor;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Medicamento medicamentoAtualizado = (Medicamento)registroAtualizado;

            Nome = medicamentoAtualizado.Nome;
            Descricao = medicamentoAtualizado.Descricao;
            Lote = medicamentoAtualizado.Lote;
            Validade = medicamentoAtualizado.Validade;
            Fornecedor = medicamentoAtualizado.Fornecedor;
        }

        public void AdicionarQuantidade(int qtd)
        {
            Quantidade += qtd;
        }

        public void RemoverQuantidade(int qtd)
        {
            QuantidadeRequisicoesSaida++;
            Quantidade -= qtd;
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            DateTime hoje = DateTime.Now.Date;

            if (string.IsNullOrWhiteSpace(Nome))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrWhiteSpace(Lote))
                erros.Add("O campo \"lote\" é obrigatório");

            if (Validade < hoje)
                erros.Add("O campo \"validade\" não pode ser menor que a data atual");

            if (Fornecedor == null)
                erros.Add("O campo \"fornecedor\" é obrigatório");

            if (Quantidade < 0)
                erros.Add("O campo \"quantidade\" não pode ser menor que 0");

            return erros;
        }
    }
}
