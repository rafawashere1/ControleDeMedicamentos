using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    internal class Requisicao
    {
        public Paciente Paciente { get; set; }
        public Medicamento Medicamento { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime Data { get; set; }
        public int QuantidadeMedicamento { get; set; }
    }
}
