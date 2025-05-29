using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public class TelaPrincipal
    {
        private char opcaoEscolhida;

        private RepositorioFabricante repositFabricante;
        private RepositorioEquipamento repositEquip;
        private RepositorioChamado repositChamado;

        private TelaFabricante telaFabricante;
        private TelaEquipamento telaEquip;
        private TelaChamado telaChamado;

        public TelaPrincipal()
        {
            repositFabricante = new RepositorioFabricante();
            repositEquip = new RepositorioEquipamento();
            repositChamado = new RepositorioChamado();

            telaFabricante = new TelaFabricante(repositFabricante);

            telaEquip = new TelaEquipamento(repositEquip, repositFabricante);

            telaChamado = new TelaChamado(repositChamado, repositEquip);
        }

        public void  ApresentarMenuPrincipal()
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
            opcaoEscolhida = Console.ReadLine()[0];
        }

        public TelaBase ObterTela()
        {
            if (opcaoEscolhida == '1')
                return telaEquip;

            else if (opcaoEscolhida == '2')
                return telaChamado;

            else if (opcaoEscolhida == '3')
                return telaFabricante;

            return null;
        }
    }
}
