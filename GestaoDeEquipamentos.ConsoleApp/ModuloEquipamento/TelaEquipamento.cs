using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp
{
    public class TelaEquipamento : TelaBase
    {
        private RepositorioEquipamento repositEquip;
        public RepositorioFabricante repositFabri;

        public TelaEquipamento(
            RepositorioEquipamento repositorioEquip,
            RepositorioFabricante repositorioFabri): base("Equipamento", repositorioEquip)
        {
            this.repositEquip = repositorioEquip;
            this.repositFabri = repositorioFabri;
        }

        public override void VisualizarRegistros()
        {
            Console.WriteLine("Visualização de Equipamentos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            EntidadeBase[] equipamentos = repositEquip.SelecionarRegistros();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = (Equipamento)equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                    e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante, e.dataFabricacao.ToShortDateString()
                );
            }

            Console.ReadLine();
        }

        protected override Equipamento ObterDados()
        {
            Console.WriteLine("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o preço de aquisição do equipamento: ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Digite o número de série do equipamento: ");
            string numeroSerie = Console.ReadLine();

            Console.WriteLine("Digite o nome da fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            Console.WriteLine("Digite a data de fabricação do equipamento: ");
            DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

            Equipamento equipamento = new Equipamento(nome, precoAquisicao, numeroSerie, 
                fabricante, dataFabricacao);

            return equipamento;
        }
    }
}
