using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante : TelaBase<Fabricante>, ITela
    {
        private RepositorioFabricante repositorioFabricante;

        public TelaFabricante(RepositorioFabricante repositorioFab) : 
            base("Fabricante", repositorioFab)
        {
            repositorioFabricante = repositorioFab;
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

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

        protected override Fabricante ObterDados()
        {
            Console.Write("Digite o nome do fabricante: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o endereço de email do fabricante: ");
            string email = Console.ReadLine();

            Console.Write("Digite o telefone do fabricante: ");
            string telefone = Console.ReadLine();

            Fabricante fabricante = new Fabricante(nome, email, telefone);

            return fabricante;
        }
    }
}
