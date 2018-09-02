using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TesteTria.Entities;
using TesteTria.Models;

namespace TesteTria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private Context _context;
        public ClienteController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<ClienteEntity> Post(ClienteModel cliente)
        {

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return ConverterCliente(_context.Clientes.Where(x => x.ClienteId == cliente.ClienteId));
        }

        [HttpGet("Relatorio/{tipo}")]
        public ActionResult<IEnumerable<ClienteModel>> Get(char tipo)
        {
            if (tipo == 'H')
            {
                return _context.Clientes.OrderBy(x => x.DataHoraConversa).ToList();
                return _context.Clientes.OrderBy(x => x.DataHoraConversa).ToList();
            }
            return _context.Clientes.OrderBy(x => x.NomeContato).ToList();
        }

        [HttpGet("{clienteId}")]
        public ActionResult<ClienteEntity> Get(int clienteId)
        {
            var cliente = _context.Clientes.Where(x => x.ClienteId == clienteId);
            if (!cliente.Any())
            {
                return BadRequest("Não foi encontrado nenhum cliente com esse ID");
            }
            return ConverterCliente(cliente);
        }

        private ClienteEntity ConverterCliente(IQueryable<ClienteModel> cliente)
        {
            ClienteEntity clienteEntidade = new ClienteEntity(cliente.First(), _context.ServicoModel.Where(x => x.ServicoId == cliente.First().ServicoId).First());
            return clienteEntidade;
        }

        [HttpDelete("{clienteId}")]
        public void Delete(int clienteId)
        {
            _context.Clientes.Remove(_context.Clientes.Where(x => x.ClienteId == clienteId).First());
            _context.SaveChanges();
        }

        // [HttpGet]
        // [Route("PesquisarServicos")]
        // public ActionResult<IEnumerable<ServicoModel>> PesquisarServicos()
        // {
        //     var a = _context.ServicoModel.ToList();
        //     return a;
        // }
    }
}
