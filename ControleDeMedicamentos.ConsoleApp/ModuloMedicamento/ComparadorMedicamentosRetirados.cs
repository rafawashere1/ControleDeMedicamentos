using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class ComparadorMedicamentosRetirados : IComparer
    {
        public int Compare(object x, object y)
        {
            Medicamento mX = (Medicamento)x;

            Medicamento mY = (Medicamento)y;

            if (mX.QuantidadeRequisicoesSaida < mY.QuantidadeRequisicoesSaida)
                return 1;

            else if (mX.QuantidadeRequisicoesSaida > mY.QuantidadeRequisicoesSaida)
                return -1;

            else
                return 0;
        }
    }
}
