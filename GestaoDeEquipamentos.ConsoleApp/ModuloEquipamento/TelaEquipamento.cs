namespace GestaoDeEquipamentos.ConsoleApp
{
    public class TelaEquipamento
    {
        public RepositorioEquipamento repositEquip;

        public char ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1 - Cadastro de Equipamento");
            Console.WriteLine("2 - Visualizar Equipamentos");
            Console.WriteLine("3 - Editar Equipamentos");
            Console.WriteLine("4 - Excluir Equipamentos");
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
            Console.WriteLine("Cadastro de Equipamentos");
            Console.WriteLine("----------------------------");

            Equipamento equipamento = ObterDados();

            repositEquip.CadastrarEquipamento(equipamento);

            Console.WriteLine($"\nO equipamento: \"{equipamento.nome}\" foi cadastrado com sucesso!");
            Console.ReadLine();
        }

        public void VisualizarRegistros()
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

        public void EditarRegistro()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Edição de Equipamentos");
            Console.WriteLine("----------------------------");

            VisualizarRegistros();

            Console.WriteLine("Digite o ID no registro que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoAtualizado = ObterDados();

            bool conseguiuEditar = repositEquip.EditarEquipamento(idSelecionado, equipamentoAtualizado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi posssível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nO equipamento: \"{equipamentoAtualizado.nome}\" foi editado com sucesso!");
            Console.ReadLine();
        }

        public Equipamento ObterDados()
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

            Equipamento equipamento = new Equipamento();
            equipamento.nome = nome;
            equipamento.precoAquisicao = precoAquisicao;
            equipamento.numeroSerie = numeroSerie;
            equipamento.fabricante = fabricante;
            equipamento.dataFabricacao = dataFabricacao;

            return equipamento;
        }

        public void ExcluirRegistro()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Exclusão de Equipamentos");
            Console.WriteLine("----------------------------");

            VisualizarRegistros();

            Console.WriteLine("Digite o ID no registro que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositEquip.ExcluirEquipamento(idSelecionado);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Não foi posssível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nO equipamento foi excluído com sucesso!");
            Console.ReadLine();
        }
    }
}
