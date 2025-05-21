using System.Globalization;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioEquipamento repositEquip = new RepositorioEquipamento();
            RepositorioChamado repositChamado = new RepositorioChamado();
            RepositorioFabricante repositFabricante = new RepositorioFabricante();

            TelaFabricante telaFabricante = new TelaFabricante(repositFabricante);

            TelaEquipamento telaEquip = new TelaEquipamento(repositEquip);

            TelaChamado telaChamado = new TelaChamado(repositChamado, repositEquip);

            while (true)
            {
                char telaEscolhida = ApresentarMenuPrincipal();

                if (telaEscolhida == 'S' || telaEscolhida == 's')
                    break;

                if (telaEscolhida == '1')
                {
                    char opcaoEscolhida = telaEquip.ApresentarMenu();

                    if (opcaoEscolhida == 'S')
                        break;

                    switch (opcaoEscolhida)
                    {
                        case '1':
                            telaEquip.CadastrarRegistro();
                            break;

                        case '2':
                            telaEquip.VisualizarRegistros();
                            break;

                        case '3':
                            telaEquip.EditarRegistro();
                            break;

                        case '4':
                            telaEquip.ExcluirRegistro();
                            break;
                    }
                }

                else if (telaEscolhida == '2')
                {
                    char opcaoEscolhida = telaChamado.ApresentarMenu();

                    if (opcaoEscolhida == 'S')
                        break;

                    switch (opcaoEscolhida)
                    {
                        case '1':
                            telaChamado.CadastrarRegistro();
                            break;

                        case '2':
                            telaChamado.VisualizarRegistros();
                            break;

                        case '3':
                            telaChamado.EditarRegistro();
                            break;

                        case '4':
                            telaChamado.ExcluirRegistro();
                            break;
                    }
                }

                else if (telaEscolhida == '3')
                {
                    char opcaoEscolhida = telaFabricante.ApresentarMenu();

                    if (opcaoEscolhida == 'S')
                        break;

                    switch (opcaoEscolhida)
                    {
                        case '1':
                            telaFabricante.CadastrarRegistro();
                            break;

                        case '2':
                            telaFabricante.VisualizarRegistros();
                            break;

                        case '3':
                            telaFabricante.EditarRegistro();
                            break;

                        case '4':
                            telaFabricante.ExcluirRegistro();
                            break;
                    }
                }
            }
        }

        public static char ApresentarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1 - Controle de Equipametos");
            Console.WriteLine("2 - Controle de Chamados");
            Console.WriteLine("3 - Controle de Fabricantes");
            Console.WriteLine("S - Sair");
            Console.WriteLine("----------------------------");

            Console.WriteLine("Escolha uma opção");
            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }
    }
}
