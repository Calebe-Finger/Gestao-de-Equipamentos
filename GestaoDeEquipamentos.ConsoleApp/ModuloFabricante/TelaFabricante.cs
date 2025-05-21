
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante
    {
        private RepositorioFabricante repositorioFabricante;

        public TelaFabricante(RepositorioFabricante repositorioF)
        {
            repositorioFabricante = repositorioF;
        }

        public char ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1 - Cadastro de Fabricante");
            Console.WriteLine("2 - Visualizar Fabricantes");
            Console.WriteLine("3 - Editar Fabricantes");
            Console.WriteLine("4 - Excluir Fabricantes");
            Console.WriteLine("S - Sair");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Digite uma opção válida: ");

            char OpcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return OpcaoEscolhida;
        }

        public void CadastrarRegistro()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Cadastro de Fabricantes");
            Console.WriteLine("--------------------------------------");

            Fabricante novoFabricante = ObterDados();

            string erros = novoFabricante.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;      //muda a cor da fonte para vermelho
                Console.WriteLine($"Erros: \n{erros}");
                Console.ResetColor();                               //volta a cor para a original

                Console.Write("\nDigite ENTER para cadastrar novamente...");
                Console.ReadLine();

                //Recursão: Quando um método chama ele mesmo
                CadastrarRegistro();

                return;
            }

            repositorioFabricante.CadastrarRegistro(novoFabricante);

            Console.WriteLine($"Fabricante \"{novoFabricante.nome}\" cadastrado com sucesso!");
            Console.ReadLine();
        }

        public void EditarRegistro()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Edição de Fabricantes");
            Console.WriteLine("--------------------------------------");

            VisualizarRegistros();

            Console.WriteLine("Digite o ID no registro que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Fabricante fabricanteAtualizado = ObterDados();

            repositorioFabricante.EditarRegistro(idSelecionado, fabricanteAtualizado);

            Console.WriteLine($"Fabricante \"{fabricanteAtualizado.nome}\" editado com sucesso!");
            Console.ReadLine();
        }

        public void VisualizarRegistros()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Visualização de Fabricantes");
            Console.WriteLine("----------------------------");

            Console.WriteLine(
                "{0, -4} | {1, -40} | {2, -40} | {3, -14}",
                "Id", "Nome", "Email", "Telefone"
            );

            EntidadeBase[] fabricantes = repositorioFabricante.SelecionarRegistros();

            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante f = (Fabricante)fabricantes[i];

                if (f == null)
                    continue;

                Console.WriteLine(
                    "{0, -4} | {1, -40} | {2, -40} | {3, -14}",
                    f.id, f.nome, f.email, f.telefone
                );
            }
            Console.ReadLine();
        }

        public void ExcluirRegistro()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Exclusão de Fabricantes");
            Console.WriteLine("--------------------------------------");

            VisualizarRegistros();

            Console.WriteLine("Digite o ID no registro que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            repositorioFabricante.ExcluirRegistro(idSelecionado);

            Console.WriteLine($"Fabricante excluido com sucesso!");
            Console.ReadLine();
        }

        private Fabricante ObterDados()
        {
            Console.WriteLine("Digite o nome do fabricante: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o endereço de email do fabricante: ");
            string email = Console.ReadLine();

            Console.WriteLine("Digite o telefone do fabricante: ");
            string telefone = Console.ReadLine();

            Fabricante fabricante = new Fabricante(nome, email, telefone);

            return fabricante;
        }
    }
}
