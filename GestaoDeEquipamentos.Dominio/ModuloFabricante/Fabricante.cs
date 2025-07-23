using System.Net.Mail;
using GestaoDeEquipamentos.Dominio.Compartilhado;

namespace GestaoDeEquipamentos.Dominio.ModuloFabricante
{
    public class Fabricante : EntidadeBase<Fabricante>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Fabricante(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O nome é obrigatório!\n";

            else if (Nome.Length < 2)
                erros += "O nome deve conter mais de um caractere!\n";

            if (!MailAddress.TryCreate(Email, out _))
                erros += "O email deve conter um formato válido \"nome@provedor.com\"!\n";

            if (string.IsNullOrWhiteSpace(Telefone))
                erros += "O telefone é obrigatório!\n";

            else if (Telefone.Length < 9)
                erros += "O telefone deve conter no mínimo nove caracteres!\n";

            return erros;
        } 

        public override void AtualizarRegistro(Fabricante registroAtualizado)
        {
            Nome = registroAtualizado.Nome;
            Email = registroAtualizado.Email;
            Telefone = registroAtualizado.Telefone;
        }
    }
}

