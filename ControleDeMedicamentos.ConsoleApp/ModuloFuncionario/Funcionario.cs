using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class Funcionario : Entidade
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Endereco Endereco { get; set; }

        public Funcionario()
        {
            
        }

        public Funcionario(string nome, string cpf, string login, string senha, string telefone, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            Login = login;
            Senha = senha;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
