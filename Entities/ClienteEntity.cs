using System;
using TesteTria.Models;

namespace TesteTria.Entities
{
    public class ClienteEntity
    {
        public int ClienteId { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string ConteudoConversa { get; set; }
        public DateTime DataHoraConversa { get; set; }
        public ServicoModel Servico { get; set; }

        public ClienteEntity(ClienteModel ClienteModel, ServicoModel Servico)
        {
            this.ClienteId = ClienteModel.ClienteId;
            this.NomeEmpresa = ClienteModel.NomeEmpresa;
            this.NomeContato = ClienteModel.NomeContato;
            this.Telefone = ClienteModel.Telefone;
            this.Email = ClienteModel.Email;
            this.ConteudoConversa = ClienteModel.ConteudoConversa;
            this.DataHoraConversa = ClienteModel.DataHoraConversa;
            this.Servico = Servico;
        }
    }
}