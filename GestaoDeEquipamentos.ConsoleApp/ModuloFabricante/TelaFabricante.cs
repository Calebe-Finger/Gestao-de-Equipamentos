
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante : TelaBase
    {
        private RepositorioFabricante repositorioFabricante;

        public TelaFabricante(RepositorioFabricante repositorioFab) : 
            base("Fabricante", repositorioFab)
        {
            repositorioFabricante = repositorioFab;
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

        protected override Fabricante ObterDados()
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
