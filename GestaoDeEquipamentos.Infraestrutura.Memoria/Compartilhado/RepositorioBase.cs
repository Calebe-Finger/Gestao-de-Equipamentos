using GestaoDeEquipamentos.Dominio.Compartilhado;
using Microsoft.Win32;

namespace GestaoDeEquipamentos.Infraestrutura.Compartilhado
{
    public abstract class RepositorioBase<Tipo> where Tipo : EntidadeBase<Tipo>
    {
        protected List<Tipo> registros = new List<Tipo>();
        protected static int contadorIds = 0;

        public void CadastrarRegistro(Tipo novoRegistro)
        {
            novoRegistro.Id = ++contadorIds;

            registros.Add(novoRegistro);
        }

        public bool EditarRegistro(int idSelecionado, Tipo registroAtualizado)
        {
            Tipo registroSelecionado = SelecionarRegistroPorId(idSelecionado);

            if (registroSelecionado == null )
                return false;

            registroSelecionado.AtualizarRegistro(registroAtualizado);

            return true;            
        }

        public bool ExcluirRegistro(int idSelecionado)
        {
            Tipo registroSelecionado = SelecionarRegistroPorId(idSelecionado);

            if (registroSelecionado is null)
                return false;

            registros.Remove(registroSelecionado);

            return true;
        }

        public List<Tipo> SelecionarRegistros()
        {
            return registros;
        }

        public Tipo SelecionarRegistroPorId(int idSelecionado)
        {
            foreach (Tipo registro in registros)
            {
                if (registro.Id.Equals(idSelecionado))
                    return registro;
            }

            return null;
        }

    }
}


