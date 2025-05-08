using System.Globalization;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaEquipamento telaEquip = new TelaEquipamento();
            TelaChamado telaChama = new TelaChamado();

            while (true)
            {
                char telaEscolhida = '\0';

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
                    char opcaoEscolhida = telaChama.ApresentarMenu();

                    if (opcaoEscolhida == 'S')
                        break;

                    switch (opcaoEscolhida)
                    {
                        case '1':
                            telaChama.CadastrarRegistro();
                            break;

                        case '2':
                            telaChama.VisualizarRegistros();
                            break;

                        case '3':
                            telaChama.EditarRegistro();
                            break;

                        case '4':
                            telaChama.ExcluirRegistro();
                            break;
                    }
                }
            }
        }
    }
}
