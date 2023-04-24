using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    internal class RepositorioPaciente : Repositorio
    {
        private List<Paciente> listaPacientes = new();

        private readonly RepositorioEndereco _repositorioEndereco;

        public RepositorioPaciente(RepositorioEndereco repositorioEndereco)
        {
            _repositorioEndereco = repositorioEndereco;
        }

        internal void Inserir(Paciente novoPaciente)
        {
            listaPacientes.Add(novoPaciente);
        }

        internal void Editar(Paciente pacienteAntigo, Paciente pacienteNovo)
        {
            pacienteAntigo.Nome = pacienteNovo.Nome;
            pacienteAntigo.Cpf = pacienteNovo.Cpf;
            pacienteAntigo.CartaoSus = pacienteNovo.CartaoSus;
            pacienteAntigo.Telefone = pacienteNovo.Telefone;
            pacienteAntigo.Endereco = pacienteNovo.Endereco;
        }
        internal void Excluir(Paciente paciente)
        {
            listaPacientes.Remove(paciente);
        }

        public void PopularListaPaciente()
        {
            List<Endereco> listaEnderecos = _repositorioEndereco.SelecionarTodos();

            Endereco endereco = listaEnderecos.Find(x => x.Id == 1);

            Paciente paciente = new("Rafael Santos", "044.748.180-08", "701 2000 7660 7217", "(51) 9 9661-6240", endereco);

            Inserir(paciente);
        }

        public List<Paciente> SelecionarTodos()
        {
            return listaPacientes;
        }
    }
}
