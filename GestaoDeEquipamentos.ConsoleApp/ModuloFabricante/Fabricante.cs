using System.Net.Mail;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class Fabricante
    {
        public int id;
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

        public void AtualizarRegistro(Fabricante fabricanteAtualizado)
        {
            this.nome = fabricanteAtualizado.nome;
            this.email = fabricanteAtualizado.email;
            this.telefone = fabricanteAtualizado.telefone;
        }
    }
}
