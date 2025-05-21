
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado
    {
        private RepositorioEquipamento repositEquip;
        private RepositorioChamado repositChamado;

        public TelaChamado(RepositorioChamado repositorioC, RepositorioEquipamento repositE)
        {
            repositChamado = repositorioC;
            repositEquip = repositE;
        }

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

            Chamado novoChamado = ObterDados();

            string erros = novoChamado.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;      //muda a cor da fonte para vermelho
                Console.WriteLine($"Erros: \n{erros}");
                Console.ResetColor();                            //volta a cor para a original

                Console.Write("\nDigite ENTER para cadastrar novamente...");
                Console.ReadLine();

                //Recursão: Quando um método chama ele mesmo
                CadastrarRegistro();

                return;
            }

            repositChamado.CadastrarRegistro(novoChamado);

            Console.WriteLine($"\nO Chamado: \"{novoChamado.titulo}\" foi cadastrado com sucesso!");
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

            bool conseguiuEditar = repositChamado.EditarRegistro(idSelecionado, chamadoAtualizado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi posssível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nO chamado: \"{chamadoAtualizado.titulo}\" foi editado com sucesso!");
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

            EntidadeBase[] chamados = repositChamado.SelecionarRegistros();

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

        public void ExcluirRegistro()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Exclusão de Chamados");
            Console.WriteLine("----------------------------");

            VisualizarRegistros();

            Console.WriteLine("Digite o ID no registro que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositChamado.ExcluirRegistro(idSelecionado);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Não foi posssível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nO chamado foi excluído com sucesso!");
            Console.ReadLine();
        }

        private Chamado ObterDados()
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