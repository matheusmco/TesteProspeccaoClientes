using System;
using System.Collections.Generic;

namespace TesteTria.Dtos
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
        public List<string> NomeServico { get; set; }
    }
}