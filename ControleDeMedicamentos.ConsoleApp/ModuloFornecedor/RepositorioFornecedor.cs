using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    internal class RepositorioFornecedor
    {
        private List<Fornecedor> listaFornecedores = new();

        private readonly RepositorioEndereco _repositorioEndereco;

        public RepositorioFornecedor(RepositorioEndereco repositorioEndereco)
        {
            _repositorioEndereco = repositorioEndereco;
        }

        internal void Inserir(Fornecedor novoFornecedor)
        {
            listaFornecedores.Add(novoFornecedor);
        }

        internal void Editar(Fornecedor fornecedorAntigo, Fornecedor fornecedorNovo)
        {
            fornecedorAntigo.Nome = fornecedorNovo.Nome;
            fornecedorAntigo.Cnpj = fornecedorNovo.Cnpj;
            fornecedorAntigo.Telefone = fornecedorNovo.Telefone;
            fornecedorAntigo.Email = fornecedorNovo.Email;
            fornecedorAntigo.Endereco = fornecedorNovo.Endereco;
        }
        internal void Excluir(Fornecedor fornecedor)
        {
            listaFornecedores.Remove(fornecedor);
        }

        public void PopularListaFornecedor()
        {
            List<Endereco> listaEnderecos = _repositorioEndereco.SelecionarTodos();

            Endereco endereco = listaEnderecos.Find(x => x.Id == 1);

            Fornecedor fornecedor = new("Rafael Santos", "24.646.496/0001-33", "(51) 9 9661-6240", "rafael@fornecedor.com", endereco);

            Inserir(fornecedor);
        }

        public List<Fornecedor> SelecionarTodos()
        {
            return listaFornecedores;
        }
    }
}
