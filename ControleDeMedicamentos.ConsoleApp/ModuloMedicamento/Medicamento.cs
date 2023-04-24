using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class Medicamento : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public Medicamento()
        {
            
        }

        public Medicamento(string nome, string descricao, int quantidadeDisponivel, Fornecedor fornecedor)
        {
            Nome = nome;
            Descricao = descricao;
            QuantidadeDisponivel = quantidadeDisponivel;
            Fornecedor = fornecedor;
        }
    }
}
