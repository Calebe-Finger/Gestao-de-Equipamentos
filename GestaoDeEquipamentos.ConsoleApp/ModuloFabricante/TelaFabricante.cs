
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

        public override void VisualizarRegistros()
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
