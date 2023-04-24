using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class RepositorioMedicamento : Repositorio
    {
        private List<Medicamento> listaMedicamentos = new();

        private readonly RepositorioFornecedor _repositorioFornecedor;

        public RepositorioMedicamento(RepositorioFornecedor repositorioFornecedor)
        {
            _repositorioFornecedor = repositorioFornecedor;
        }

        internal void Inserir(Medicamento novoMedicamento)
        {
            listaMedicamentos.Add(novoMedicamento);
        }

        internal void Editar(Medicamento medicamentoAntigo, Medicamento medicamentoNovo)
        {
            medicamentoAntigo.Nome = medicamentoNovo.Nome;
            medicamentoAntigo.Descricao = medicamentoNovo.Descricao;
            medicamentoAntigo.QuantidadeDisponivel = medicamentoNovo.QuantidadeDisponivel;
            medicamentoAntigo.Fornecedor = medicamentoNovo.Fornecedor;
        }
        internal void Excluir(Medicamento medicamento)
        {
            listaMedicamentos.Remove(medicamento);
        }

        public void PopularListaMedicamento()
        {
            List<Fornecedor> listaFornecedores = _repositorioFornecedor.SelecionarTodos();

            Fornecedor fornecedor =listaFornecedores.Find(x => x.Id == 1);

            Medicamento medicamento = new("Paracetamol", "Dor de Cabeça", 10, fornecedor);

            Inserir(medicamento);
        }

        public List<Medicamento> SelecionarTodos()
        {
            return listaMedicamentos;
        }
    }
}
