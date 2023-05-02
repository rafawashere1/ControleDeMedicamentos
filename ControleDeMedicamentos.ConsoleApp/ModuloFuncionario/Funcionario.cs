using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Endereco Endereco { get; set; }

        public Funcionario(string nome, string login, string senha, string telefone, Endereco endereco)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Telefone = telefone;
            Endereco = endereco;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Funcionario funcionarioAtualizado = (Funcionario)registroAtualizado;

            Nome = funcionarioAtualizado.Nome;
            Telefone = funcionarioAtualizado.Telefone;
            Login = funcionarioAtualizado.Login;
            Senha = funcionarioAtualizado.Senha;
            Endereco = funcionarioAtualizado.Endereco;
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (string.IsNullOrWhiteSpace(Nome))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrWhiteSpace(Login))
                erros.Add("O campo \"login\" é obrigatório");

            if (string.IsNullOrWhiteSpace(Senha))
                erros.Add("O campo \"senha\" é obrigatório");

            if (string.IsNullOrWhiteSpace(Telefone))
                erros.Add("O campo \"telefone\" é obrigatório");

            return erros;
        }
    }
}
