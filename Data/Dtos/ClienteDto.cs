using System;
using System.Collections.Generic;

namespace TesteProspeccaoClientes.Data.Dtos
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string ConteudoConversa { get; set; }
        public DateTime DataHoraConversa { get; set; }
        public List<ServicoDto> Servicos { get; set; }
    }
}