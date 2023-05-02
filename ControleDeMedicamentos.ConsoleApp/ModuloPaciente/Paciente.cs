using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEndereco;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : EntidadeBase
    {
        public string Nome { get; set; }
        public string CartaoSus { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public Paciente(string nome, string cartaoSus, string telefone, Endereco endereco)
        {
            Nome = nome;
            CartaoSus = cartaoSus;
            Telefone = telefone;
            Endereco = endereco;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Paciente pacienteAtualizado = (Paciente)registroAtualizado;

            Nome = pacienteAtualizado.Nome;
            CartaoSus = pacienteAtualizado.CartaoSus;
            Telefone = pacienteAtualizado.Telefone;
            Endereco = pacienteAtualizado.Endereco;
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (string.IsNullOrWhiteSpace(Nome))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrWhiteSpace(CartaoSus))
                erros.Add("O campo \"cartaoSUS\" é obrigatório");

            if(string.IsNullOrWhiteSpace(Telefone))
                erros.Add("O campo \"telefone\" é obrigatório");

            return erros;
        }
    }
}
