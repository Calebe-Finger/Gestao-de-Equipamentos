using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp
{
    public class Equipamento
    {
        public int id;
        public string nome;
        public decimal precoAquisicao;
        public string numeroSerie;
        public string fabricante;
        public DateTime dataFabricacao;

        public Equipamento(string nome, decimal precoAquisicao, string numeroSerie,
            string fabricante, DateTime dataFabricacao)
        {
            this.nome = nome;
            this.precoAquisicao = precoAquisicao;
            this.numeroSerie = numeroSerie;
            this.fabricante = fabricante;
            this.dataFabricacao = dataFabricacao;
        }
    }
}
