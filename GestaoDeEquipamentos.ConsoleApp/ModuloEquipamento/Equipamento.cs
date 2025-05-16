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

        public string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(nome))
                erros += "O nome é obrigatório!\n";

            else if (nome.Length < 2)
                erros += "O nome deve conter mais de um caractere!\n";

            if (precoAquisicao <= 0)
                erros += "É necessário que haja um preço de aquisição válido!\n";

            if (string.IsNullOrWhiteSpace(numeroSerie))
                erros += "O número de serie é obrigatório!\n";

            if (string.IsNullOrWhiteSpace(fabricante))
                erros += "O fabricante é obrigatório!\n";

            else if (fabricante.Length < 3)
                erros += "O fabricante deve conter mais de dois caracteres!\n";

            return erros;
        }

        public void AtualizarRegistro(Equipamento equipamentoAtualizado)
        {
            this.nome = equipamentoAtualizado.nome;
            this.precoAquisicao = equipamentoAtualizado.precoAquisicao;
            this.numeroSerie = equipamentoAtualizado.numeroSerie;
            this.fabricante = equipamentoAtualizado.fabricante;
            this.dataFabricacao = equipamentoAtualizado.dataFabricacao;
        }
    }
}
