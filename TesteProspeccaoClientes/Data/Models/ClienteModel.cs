using System;
using System.Collections.Generic;

namespace TesteProspeccaoClientes.Data.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string ConteudoConversa { get; set; }
        public DateTime DataHoraConversa { get; set; }
        public List<ClienteServicoModel> ClienteServico { get; set; }
    }
}