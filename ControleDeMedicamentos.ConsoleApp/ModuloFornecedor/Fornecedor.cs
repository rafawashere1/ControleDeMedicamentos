using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor

{
    public class Fornecedor : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }


        public Fornecedor(string nome, string telefone, string email, Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Fornecedor fornecedorAtualizado = (Fornecedor)registroAtualizado;

            Nome = fornecedorAtualizado.Nome;
            Telefone = fornecedorAtualizado.Telefone;
            Email = fornecedorAtualizado.Email;
            Endereco = fornecedorAtualizado.Endereco;
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (string.IsNullOrWhiteSpace(Nome))
                erros.Add("O campo \"nome\" é obrigatório");

            if (Nome.Length <= 3)
                erros.Add("O campo \"nome\" precisa ter mais que 3 letras");

            if (string.IsNullOrWhiteSpace(Telefone))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrWhiteSpace(Email))
                erros.Add("O campo \"email\" é obrigatório");

            return erros;
        }
    }
}
