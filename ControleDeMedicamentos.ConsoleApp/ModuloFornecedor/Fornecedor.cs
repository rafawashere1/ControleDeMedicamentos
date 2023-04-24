using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor

{
    internal class Fornecedor : Entidade
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }


        public Fornecedor()
        {
            
        }

        public Fornecedor(string nome, string cnpj, string telefone, string email, Endereco endereco)
        {
            Nome = nome;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }
    }
}
