using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    public class Chamado : EntidadeBase
    {
        public int id;
        public string titulo;
        public string descricao;
        public DateTime dataAbertura;

        public Equipamento equipamento;

        public Chamado(string titulo, string descricao, DateTime dataAbertura, Equipamento equipamento)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.dataAbertura = dataAbertura;
            this.equipamento = equipamento;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(titulo))
                erros += "O título é obrigatório!\n";

            else if (titulo.Length < 3)
                erros += "O título deve conter mais de dois caracteres!\n";

            if (string.IsNullOrWhiteSpace(descricao))
                erros += "A descrição é obrigatória!\n";

            else if (descricao.Length < 3)
                erros += "A descrição deve conter mais de dois caracteres!\n";

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Chamado chamadoAtualizado = (Chamado)registroAtualizado;

            this.titulo = chamadoAtualizado.titulo;
            this.descricao = chamadoAtualizado.descricao;
            this.dataAbertura = chamadoAtualizado.dataAbertura;
            this.equipamento = chamadoAtualizado.equipamento;
        }
    }
}
