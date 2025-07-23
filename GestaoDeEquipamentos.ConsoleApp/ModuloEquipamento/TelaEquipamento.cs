using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.ModuloEquipamento;
using GestaoDeEquipamentos.Infraestrutura.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp
{
    public class TelaEquipamento : TelaBase<Equipamento>, ITela
    {
        private RepositorioEquipamento repositEquip;
        private RepositorioFabricante repositFabri;

        public TelaEquipamento(
            RepositorioEquipamento repositorioEquip,
            RepositorioFabricante repositorioFabri) : base("Equipamento", repositorioEquip)
        {
            this.repositEquip = repositorioEquip;
            this.repositFabri = repositorioFabri;
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Equipamentos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            List<Equipamento> equipamentos = repositorioEquipamento.SelecionarRegistros();

            foreach (Equipamento e in equipamentos)
            {
                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                    e.Id, e.Nome, e.PrecoAquisicao.ToString("C2"), e.NumeroSerie, e.Fabricante.Nome, e.DataFabricacao.ToShortDateString()
                );
            }

            Console.ReadLine();
        }

        public void VisualizarFabricantes()
        {
            Console.WriteLine();

            Console.WriteLine("Visualização de Fabricantes");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                "Id", "Nome", "Email", "Telefone"
            );

            List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

            foreach (Fabricante f in fabricantes)
            {

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                    f.Id, f.Nome, f.Email, f.Telefone
                );
            }

            Console.ReadLine();
        }

        protected override Equipamento ObterDados()
        {
            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o preço de aquisição do equipamento: ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite o número de série do equipamento: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação do equipamento: ");
            DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

            VisualizarFabricantes();

            Console.Write("Digite o id do fabricante do equipamento: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());

            Fabricante fabricanteSelecionado =
                repositorioFabricante.SelecionarRegistroPorId(idFabricante);

            Equipamento equipamento = new Equipamento(
                nome,
                precoAquisicao,
                numeroSerie,
                fabricanteSelecionado,
                dataFabricacao
            );

            return equipamento;
        }
    }
}
