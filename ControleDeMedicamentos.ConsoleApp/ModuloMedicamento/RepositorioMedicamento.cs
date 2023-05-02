using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento : RepositorioBase<Medicamento>
    {
        public List<Medicamento> SelecionarMedicamentosMaisRetirados()
        {
            List<Medicamento> listaMedicamentos = SelecionarTodos();

            Medicamento[] medicamentos = ConverterParaMedicamentos(listaMedicamentos);

            Array.Sort(medicamentos, new ComparadorMedicamentosRetirados());

            return medicamentos.ToList();
        }

        private Medicamento[] ConverterParaMedicamentos(List<Medicamento> listaRegistros)
        {
            Medicamento[] medicamentos = new Medicamento[listaRegistros.Count];

            int posicao = 0;
            foreach (Medicamento m in listaRegistros)
            {
                medicamentos[posicao++] = m;
            }

            return medicamentos;
        }

        public List<Medicamento> SelecionarMedicamentosEmFalta()
        {
            List<Medicamento> listaMedicamentosEmFalta = new();

            List<Medicamento> listaMedicamentos = SelecionarTodos();

            foreach (Medicamento m in listaMedicamentos)
            {
                if (m.Quantidade == 0)
                    listaMedicamentosEmFalta.Add(m);
            }

            return listaMedicamentosEmFalta;
        }
    }
}
