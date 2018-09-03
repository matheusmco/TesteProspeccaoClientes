using System.Collections.Generic;

namespace TesteTria.Models
{
    public class ServicoModel
    {
        public int ServicoId { get; set; }
        public string NomeServico { get; set; }
        // public int ClienteId { get; set; }
        public List<ClienteServicoModel> ClienteServico { get; set; }

        public ServicoModel(/*int servicoId, */string nomeServico)
        {
            // this.ServicoId = servicoId;
            this.NomeServico = nomeServico;
        }
    }
}