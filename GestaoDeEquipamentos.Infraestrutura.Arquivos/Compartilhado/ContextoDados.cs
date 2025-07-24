using GestaoDeEquipamentos.Dominio.ModuloChamado;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado
{
    public class ContextoDados
    {
        public List<Fabricante> Fabricantes { get; set; }
        public List<Equipamento> Equipamentos { get; set; }
        public List<Chamado> Chamados { get; set; }

        private string pastaArmazenamento = "C:\\temp";
        private string arquivoArmazenamento = "dados.json";

        public ContextoDados()
        {
            Fabricantes = new List<Fabricante>();
            Equipamentos = new List<Equipamento>();
            Chamados = new List<Chamado>();
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                Carregar();
        }

        public void Salvar()
        {
            //C:\\temp\dados.json
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            string conteudoJson = JsonSerializer.Serialize(this, jsonOptions);

            Directory.CreateDirectory(pastaArmazenamento);

            File.WriteAllText(caminhoCompleto, conteudoJson);
        }

        public void Carregar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            if (!File.Exists(caminhoCompleto))
                return; 

            string conteudoJson = File.ReadAllText(caminhoCompleto);

            if (string.IsNullOrWhiteSpace(caminhoCompleto))
                return;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(conteudoJson, jsonOptions)!;

            if (contextoArmazenado == null)
                return;

            this.Fabricantes = contextoArmazenado.Fabricantes;
            this.Equipamentos = contextoArmazenado.Equipamentos;
            this.Chamados = contextoArmazenado.Chamados;


        }
    }
}

