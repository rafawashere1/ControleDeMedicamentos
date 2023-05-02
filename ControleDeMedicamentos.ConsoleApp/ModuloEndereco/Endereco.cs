using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloEndereco
{
    public class Endereco : EntidadeBase
    {
        public string Rua { get; set; }
        public string NumeroCasa { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public Endereco(string rua, string numeroCasa, string cidade, string estado, string pais)
        {
            Rua = rua;
            NumeroCasa = numeroCasa;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Endereco enderecoAtualizado = (Endereco)registroAtualizado;

            Rua = enderecoAtualizado.Rua;
            NumeroCasa = enderecoAtualizado.NumeroCasa;
            Cidade = enderecoAtualizado.Cidade;
            Estado = enderecoAtualizado.Estado;
            Pais = enderecoAtualizado.Estado;
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (string.IsNullOrWhiteSpace(Rua))
                erros.Add("O campo \"rua\" é obrigatório");

            if (string.IsNullOrWhiteSpace(NumeroCasa))
                erros.Add("O campo \"numero da casa\" é obrigatório");

            if (string.IsNullOrWhiteSpace(Cidade))
                erros.Add("O campo \"cidade\" é obrigatório");

            if (string.IsNullOrWhiteSpace(Estado))
                erros.Add("O campo \"estado\" é obrigatório");

            if (string.IsNullOrWhiteSpace(Pais))
                erros.Add("O campo \"país\" é obrigatório");

            return erros;
        }
    }
}
