namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        private readonly List<T> _listaRegistros;

        public RepositorioBase()
        {
            _listaRegistros = new List<T>();
        }

        public virtual void Inserir(T registro)
        {
            _listaRegistros.Add(registro);
        }

        public virtual void Editar(int id, T registroAtualizado)
        {
            T registroSelecionado = SelecionarPorId(id);

            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }

        public virtual void Editar(T registroSelecionado, T registroAtualizado)
        {
            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }

        public virtual void Excluir(int id)
        {
            T registroSelecionado = SelecionarPorId(id);

            _listaRegistros.Remove(registroSelecionado);
        }

        public virtual void Excluir(T registroSelecionado)
        {
            _listaRegistros.Remove(registroSelecionado);
        }

        public virtual T SelecionarPorId(int id)
        {
            return _listaRegistros.Find(x => x.Id == id);
        }

        public virtual List<T> SelecionarTodos()
        {
            return _listaRegistros;
        }

        public bool TemRegistro()
        {
            return _listaRegistros.Count > 0;
        }
    }
}