
namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado
    {
        public RepositorioEquipamento repositEquip;
        public RepositorioChamado repositChamado;

        public char ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1 - Cadastro de Chamados");
            Console.WriteLine("2 - Visualizar Chamados");
            Console.WriteLine("3 - Editar Chamados");
            Console.WriteLine("4 - Excluir Chamados");
            Console.WriteLine("S - Sair");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Digite uma opção válida: ");

            char OpcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return OpcaoEscolhida;
        }

        public void CadastrarRegistro()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Cadastro de Chamados");
            Console.WriteLine("----------------------------");

            Chamado chamado = ObterDados();

            repositChamado.CadastrarChamado(chamado);

            Console.WriteLine($"\nO Chamado: \"{chamado.titulo}\" foi cadastrado com sucesso!");
            Console.ReadLine();
        }

        public void EditarRegistro()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Edição de Chamados");
            Console.WriteLine("----------------------------");

            VisualizarRegistros();

            Console.WriteLine("Digite o ID no registro que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Chamado chamadoAtualizado = ObterDados();

            bool conseguiuEditar = repositChamado.EditarChamado(idSelecionado, chamadoAtualizado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi posssível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nO chamado: \"{chamadoAtualizado.titulo}\" foi editado com sucesso!");
            Console.ReadLine();
        }

        public void ExcluirRegistro()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Exclusão de Chamados");
            Console.WriteLine("----------------------------");

            VisualizarRegistros();

            Console.WriteLine("Digite o ID no registro que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositChamado.ExcluirChamado(idSelecionado);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Não foi posssível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nO chamado foi excluído com sucesso!");
            Console.ReadLine();
        }

        public void VisualizarRegistros()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Visualização de Chamados");
            Console.WriteLine("----------------------------");

            Console.WriteLine(
                "{0, -4} | {1, -26} | {2, -16} | {3, -14} | {4, -26}",
                "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
            );

            Chamado[] chamados = repositChamado.SelecionarChamados();

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado c = chamados[i];

                if (c == null)
                    continue;

                Console.WriteLine(
                    "{0, -4} | {1, -26} | {2, -16} | {3, -14} | {4, -26}",
                    c.id, c.titulo, c.descricao, c.dataAbertura.ToShortTimeString(), c.equipamento.nome
                );
            }
            Console.ReadLine();
        }

        public Chamado ObterDados()
        {
            Console.WriteLine("Digite o titulo do chamado: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            DateTime dataAbertura = DateTime.Now; // pega a data e hora atuais do computador

            VisualizarEquipamentos();

            Console.WriteLine("Digite o ID do chamado: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoSelecionado = repositEquip.SelecionarEquipamentoPorId(idEquipamento);

            Chamado chamado = new Chamado();
            chamado.titulo = titulo;
            chamado.descricao = descricao;
            chamado.dataAbertura = dataAbertura;
            chamado.equipamento = equipamentoSelecionado;

            return chamado;
        }

        public void VisualizarEquipamentos()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Visualização de Equipamentos");
            Console.WriteLine("----------------------------");

            Console.WriteLine(
                "{0, -4} | {1, -26} | {2, -16} | {3, -14} | {4, -26} | {5, -8} ",
                "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            Equipamento[] equipamentos = repositEquip.SelecionarEquipamentos();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

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