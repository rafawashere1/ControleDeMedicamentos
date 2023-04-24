using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    internal class Paciente : Entidade
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string CartaoSus { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public Paciente()
        {

        }

        public Paciente(string nome, string cpf, string cartaoSus, string telefone, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            CartaoSus = cartaoSus;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
