namespace TesteProspeccaoClientes.Data.Models
{
    public class ClienteServicoModel
    {
        public int ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }
        public int ServicoId { get; set; }
        public ServicoModel Servico { get; set; }
    }
}