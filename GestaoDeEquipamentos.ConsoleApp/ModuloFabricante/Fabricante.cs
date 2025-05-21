using System.Net.Mail;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class Fabricante : EntidadeBase
    {
        public string nome;
        public string email;
        public string telefone;

        public Fabricante(string nome, string email, string telefone)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
        }

        public string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(nome))
                erros += "O nome é obrigatório!\n";

            else if (nome.Length < 2)
                erros += "O nome deve conter mais de um caractere!\n";

            if (!MailAddress.TryCreate(email, out _))
                erros += "O email deve conter um formato válido \"nome@provedor.com\"!\n";

            if (string.IsNullOrWhiteSpace(telefone))
                erros += "O telefone é obrigatório!\n";

            else if (telefone.Length < 9)
                erros += "O telefone deve conter no mínimo nove caracteres!\n";

            return erros;
        } 

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Fabricante fabricanteAtualizado = (Fabricante)registroAtualizado;

            this.nome = fabricanteAtualizado.nome;
            this.email = fabricanteAtualizado.email;
            this.telefone = fabricanteAtualizado.telefone;
        }
    }
}
