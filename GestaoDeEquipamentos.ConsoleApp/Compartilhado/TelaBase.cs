namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public abstract class TelaBase
    {
        private string nomeEntidade;

        protected TelaBase(string nomeEntidade)
        {
            this.nomeEntidade = nomeEntidade;
        }

        public char ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Gestão de {nomeEntidade}s");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"1 - Cadastro de {nomeEntidade}");
            Console.WriteLine($"2 - Visualizar {nomeEntidade}s");
            Console.WriteLine($"3 - Editar {nomeEntidade}");
            Console.WriteLine($"4 - Excluir {nomeEntidade}");
            Console.WriteLine("S - Sair");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Digite uma opção válida: ");

            char OpcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return OpcaoEscolhida;
        }
    }
}
