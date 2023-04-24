using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloEndereco
{
    internal class RepositorioEndereco : Repositorio
    {
        private List<Endereco> listaEnderecos = new();

        public void Inserir(Endereco endereco)
        {
            listaEnderecos.Add(endereco);
        }
        public void PopularListaEndereco()
        {
            Endereco endereco = new("R. Itapetininga", "347", "Gravataí", "RS", "Brasil");

            Inserir(endereco);
        }

        public List<Endereco> SelecionarTodos()
        {
            return listaEnderecos;
        }
    }
}
