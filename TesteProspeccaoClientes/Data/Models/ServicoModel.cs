using System.Collections.Generic;

namespace TesteProspeccaoClientes.Data.Models
{
    public class ServicoModel
    {
        public int ServicoId { get; set; }
        public string NomeServico { get; set; }
        public List<ClienteServicoModel> ClienteServico { get; set; }
    }
}