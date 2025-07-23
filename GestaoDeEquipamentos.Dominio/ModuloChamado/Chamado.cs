using GestaoDeEquipamentos.Dominio.Compartilhado;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;

namespace GestaoDeEquipamentos.Dominio.ModuloChamado
{
    public class Chamado : EntidadeBase<Chamado>
    {
        public string Titulo {  get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public Equipamento Equipamento {  get; set; }

        public Chamado(string titulo, string descricao, DateTime dataAbertura, Equipamento equipamento)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataAbertura = dataAbertura;
            Equipamento = equipamento;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Titulo))
                erros += "O título é obrigatório!\n";

            else if (Titulo.Length < 3)
                erros += "O título deve conter mais de dois caracteres!\n";

            if (string.IsNullOrWhiteSpace(Descricao))
                erros += "A descrição é obrigatória!\n";

            else if (Descricao.Length < 3)
                erros += "A descrição deve conter mais de dois caracteres!\n";

            return erros;
        }

        public override void AtualizarRegistro(Chamado registroAtualizado)
        {
            Titulo = registroAtualizado.Titulo;
            Descricao = registroAtualizado.Descricao;
            DataAbertura = registroAtualizado.DataAbertura;
            Equipamento = registroAtualizado.Equipamento;
        }
    }
}
