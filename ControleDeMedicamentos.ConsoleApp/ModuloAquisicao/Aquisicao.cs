using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloAquisicao
{
    internal class Aquisicao
    {
        public Fornecedor Fornecedor { get; set; }
        public Medicamento Medicamento { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime Data { get; set; }
        public int QuantidadeMedicamento { get; set; }
    }
}
