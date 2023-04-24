using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloEndereco
{
    internal class Endereco : Entidade
    {
        public string Rua { get; set; }
        public string NumeroCasa { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public Endereco()
        {
            
        }

        public Endereco(string rua, string numeroCasa, string cidade, string estado, string pais)
        {
            Rua = rua;
            NumeroCasa = numeroCasa;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }
    }
}
