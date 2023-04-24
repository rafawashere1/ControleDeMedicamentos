using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class RepositorioFuncionario : Repositorio
    {
        private List<Funcionario> listaFuncionarios = new();

        private readonly RepositorioEndereco _repositorioEndereco;

        public RepositorioFuncionario(RepositorioEndereco repositorioEndereco)
        {
            _repositorioEndereco = repositorioEndereco;
        }

        internal void Inserir(Funcionario funcionario)
        {
            listaFuncionarios.Add(funcionario);
        }

        internal void Editar(Funcionario funcionarioAntigo, Funcionario funcionarioNovo)
        {
            funcionarioAntigo.Nome = funcionarioNovo.Nome;
            funcionarioAntigo.Cpf = funcionarioNovo.Cpf;
            funcionarioAntigo.Telefone = funcionarioNovo.Telefone;
            funcionarioAntigo.Login = funcionarioNovo.Login;
            funcionarioAntigo.Senha = funcionarioNovo.Senha;
            funcionarioAntigo.Endereco = funcionarioNovo.Endereco;
        }
        internal void Excluir(Funcionario funcionario)
        {
            listaFuncionarios.Remove(funcionario);
        }

        public void PopularListaFuncionario()
        {
            List<Endereco> listaEnderecos = _repositorioEndereco.SelecionarTodos();

            Endereco endereco = listaEnderecos.Find(x => x.Id == 1);

            Funcionario funcionario = new("Rafael Casa Nova dos Santos", "044.748.180-08", "admin", "admin", "(51) 9 9661-6240", endereco);

            Inserir(funcionario);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return listaFuncionarios;
        }
    }
}
