
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado : TelaBase
    {
        private RepositorioEquipamento repositEquip;
        private RepositorioChamado repositChama;

        public TelaChamado (RepositorioChamado repositChama, RepositorioEquipamento repositEquip) 
            : base("Chamado", repositChama)
        {
            this.repositChama = repositChama;
            this.repositEquip = repositEquip;
        }

        public override void VisualizarRegistros()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Visualização de Chamados");
            Console.WriteLine("----------------------------");

            Console.WriteLine(
                "{0, -4} | {1, -26} | {2, -16} | {3, -14} | {4, -26}",
                "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
            );

            EntidadeBase[] chamados = repositChama.SelecionarRegistros();

            for (int i = 0; i < chamados.Length; i++)
            {


                Chamado c = (Chamado)chamados[i];

                if (c == null)
                    continue;

                Console.WriteLine(
                    "{0, -4} | {1, -26} | {2, -16} | {3, -14} | {4, -26}",
                    c.id, c.titulo, c.descricao, c.dataAbertura.ToShortTimeString(), c.equipamento.nome
                );
            }
            Console.ReadLine();
        }

        protected override Chamado ObterDados()
        {
            Console.WriteLine("Digite o titulo do chamado: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            DateTime dataAbertura = DateTime.Now; // pega a data e hora atuais do computador

            VisualizarEquipamentos();

            Console.WriteLine("Digite o ID do chamado: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoSelecionado = (Equipamento)repositEquip.SelecionarRegistroPorId(idEquipamento);

            Chamado chamado = new Chamado(titulo, descricao, dataAbertura, equipamentoSelecionado);

            return chamado;
        }

        private void VisualizarEquipamentos()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Visualização de Equipamentos");
            Console.WriteLine("----------------------------");

            Console.WriteLine(
                "{0, -4} | {1, -26} | {2, -16} | {3, -14} | {4, -26} | {5, -8} ",
                "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            EntidadeBase[] equipamentos = repositEquip.SelecionarRegistros();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = (Equipamento)equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -4} | {1, -26} | {2, -16} | {3, -14} | {4, -26} | {5, -8} ",
                    e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante, e.dataFabricacao.ToShortDateString()
                );
            }
            Console.ReadLine();
        }
    }
}