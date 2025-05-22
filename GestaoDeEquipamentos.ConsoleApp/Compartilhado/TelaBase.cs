using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public abstract class TelaBase
    {
        protected string nomeEntidade;
        protected RepositorioBase repositorio;

        protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
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

        public void CadastrarRegistro()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Cadastro de {nomeEntidade}");
            Console.WriteLine("--------------------------------------");

            EntidadeBase novoRegistro = ObterDados();

            string erros = novoRegistro.Validar();

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

            repositorio.CadastrarRegistro(novoRegistro);

            Console.WriteLine($"{nomeEntidade} cadastrado com sucesso!");
            Console.ReadLine();
        }

        protected abstract EntidadeBase ObterDados();
    }
}
