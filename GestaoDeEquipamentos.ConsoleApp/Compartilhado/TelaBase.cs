using GestaoDeEquipamentos.Dominio.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public abstract class TelaBase<T> where T : EntidadeBase<T>
    {
        protected string nomeEntidade;
        protected RepositorioBase<T> repositorio;

        protected TelaBase(string nomeEntidade, RepositorioBase<T> repositorio)
        {
            this.nomeEntidade = nomeEntidade;
            this.repositorio = repositorio;
        }

        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Controle de {nomeEntidade}s");
            Console.WriteLine("--------------------------------------------");
        }

        public virtual char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {nomeEntidade}");
            Console.WriteLine($"2 - Editar {nomeEntidade}");
            Console.WriteLine($"3 - Excluir {nomeEntidade}");
            Console.WriteLine($"4 - Visualizar {nomeEntidade}s");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine()!);

            return operacaoEscolhida;
        }

        public virtual void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine();

            Console.WriteLine($"Cadastrando {nomeEntidade}...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            T novoRegistro = ObterDados();

            string erros = novoRegistro.Validar();

            if (erros.Length > 0)
            {
                ApresentarMensagem(erros, ConsoleColor.Red);

                CadastrarRegistro();

                return;
            }

            repositorio.CadastrarRegistro(novoRegistro);

            ApresentarMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
        }

        public virtual void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Editando {nomeEntidade}...");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idRegistro = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            T registroEditado = ObterDados();

            string erros = registroEditado.Validar();

            if (erros.Length > 0)
            {
                ApresentarMensagem(erros, ConsoleColor.Red);

                EditarRegistro();

                return;
            }

            bool conseguiuEditar = repositorio.EditarRegistro(idRegistro, registroEditado);

            if (!conseguiuEditar)
            {
                ApresentarMensagem("Houve um erro durante a edição do registro...", ConsoleColor.Red);

                return;
            }

            ApresentarMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
        }

        public virtual void ExcluirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Excluindo {nomeEntidade}...");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idRegistro = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            bool conseguiuExcluir = repositorio.ExcluirRegistro(idRegistro);

            if (!conseguiuExcluir)
            {
                ApresentarMensagem("Houve um erro durante a exclusão do registro...", ConsoleColor.Red);

                return;
            }

            ApresentarMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);
        }

        public abstract void VisualizarRegistros(bool exibirTitulo);

        protected abstract T ObterDados();

        protected void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
