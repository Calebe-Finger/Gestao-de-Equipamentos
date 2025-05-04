using System.Globalization;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaEquipamento telaEquip = new TelaEquipamento();

            while (true)
            {
                char OpcaoEscolhida = telaEquip.ApresentarMenu();

                if (OpcaoEscolhida == 'S')
                    break;

                switch (OpcaoEscolhida)
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
        }
    }
}
