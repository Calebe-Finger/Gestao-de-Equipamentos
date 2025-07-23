using GestaoDeEquipamentos.Dominio.Compartilhado;

namespace GestaoDeEquipamentos.Dominio.ModuloFabricante
{
    public class Equipamento : EntidadeBase<Equipamento>
    {
        public string Nome { get; set; }
        public decimal PrecoAquisicao { get; set; }
        public string NumeroSerie { get; set; }
        public Fabricante Fabricante { get; set; }
        public DateTime DataFabricacao { get; set; }

        public Equipamento() { }

        public Equipamento(
            string nome, 
            decimal precoAquisicao, 
            string numeroSerie,
            Fabricante fabricante, 
            DateTime dataFabricacao)
            : this()
        {
            Nome = nome;
            PrecoAquisicao = precoAquisicao;
            NumeroSerie = numeroSerie;
            Fabricante = fabricante;
            DataFabricacao = dataFabricacao;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O campo \"Nome\" é obrigatório!\n";

            else if (Nome.Length < 3)
                erros += "O campo \"Nome\" deve conter ao menos 3 caracteres!\n";

            if (PrecoAquisicao <= 0)
                erros += "O campo \"Preço de Aquisição\" deve ser maior que zero!\n";

            if (string.IsNullOrWhiteSpace(NumeroSerie))
                erros += "O campo \"Número de Série\" é obrigatório!\n";

            if (DataFabricacao > DateTime.Now)
                erros += "O campo \"Data de Fabricação\" deve conter uma data válida no passado!\n";

            return erros;
        }

        public override void AtualizarRegistro(Equipamento registroAtualizado)
        {
            Nome = registroAtualizado.Nome;
            PrecoAquisicao = registroAtualizado.PrecoAquisicao;
            NumeroSerie = registroAtualizado.NumeroSerie;
            Fabricante = registroAtualizado.Fabricante;
            DataFabricacao = registroAtualizado.DataFabricacao;
        }
    }
}
