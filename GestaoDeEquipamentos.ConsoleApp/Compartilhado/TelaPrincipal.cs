using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.ModuloChamado;
using GestaoDeEquipamentos.Infraestrutura.ModuloEquipamento;
using GestaoDeEquipamentos.Infraestrutura.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public class TelaPrincipal
    {
        private char opcaoEscolhida;

        private RepositorioFabricante repositFabricante;
        private RepositorioEquipamento repositEquip;
        private RepositorioChamado repositChamado;

        private TelaFabricante telaFabricante;
        private TelaEquipamento telaEquipamento;
        private TelaChamado telaChamado;

        public TelaPrincipal()
        {
            repositFabricante = new RepositorioFabricante();
            repositEquip = new RepositorioEquipamento();
            repositChamado = new RepositorioChamado();

            telaFabricante = new TelaFabricante(repositFabricante);

            telaEquipamento = new TelaEquipamento(repositEquip, repositFabricante);

            telaChamado = new TelaChamado(repositChamado, repositEquip);
        }

        public void  ApresentarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1 - Controle de Fabricantes");
            Console.WriteLine("2 - Controle de Equipametos");
            Console.WriteLine("3 - Controle de Chamados");
            Console.WriteLine("S - Sair");
            Console.WriteLine("----------------------------");

            Console.WriteLine("Escolha uma opção:");
            opcaoEscolhida = Console.ReadLine()[0];
        }

        public ITela? ObterTela()
        {
            if (opcaoEscolhida == '1')
                return telaFabricante;

            else if (opcaoEscolhida == '2')
                return telaEquipamento;

            else if (opcaoEscolhida == '3')
                return telaChamado;

            return null;
        }
    }
}
