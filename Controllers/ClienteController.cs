using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<ClienteModel> Post(ClienteModel Cliente)
        {
            Cliente.DataHoraConversa = DateTime.Now;
            _context.Clientes.Add(Cliente);
            _context.SaveChanges();
            var clientes = _context.Clientes.Where(x => x.ClienteId == Cliente.ClienteId).ToList();
            clientes = ValorizarServico(clientes);
            return clientes.First();
        }

        [HttpGet("Relatorio/{tipo}")]
        public ActionResult<IEnumerable<ClienteModel>> Get(char tipo)
        {
            var clientes = _context.Clientes.ToList();
            clientes = ValorizarServico(clientes);
            if (tipo == 'H')
            {
                return clientes.OrderBy(x => x.DataHoraConversa).ToList();
            }
            return clientes.OrderBy(x => x.NomeContato).ToList();
        }

        [HttpGet("{clienteId}")]
        public ActionResult<ClienteModel> Get(int clienteId)
        {
            var clientes = _context.Clientes.Where(x => x.ClienteId == clienteId).ToList();
            if (clientes.Count == 0)
            {
                return BadRequest("Não foi encontrado nenhum cliente com esse ID");
            }
            clientes = ValorizarServico(clientes);
            return clientes.First();
        }

        private List<ClienteModel> ValorizarServico(List<ClienteModel> clientes)
        {
            clientes.ForEach(x =>
            {
                x.Servico = _context.ServicoModel.Where(a => a.ServicoId == x.ServicoId).First();
            });

            return clientes;
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
