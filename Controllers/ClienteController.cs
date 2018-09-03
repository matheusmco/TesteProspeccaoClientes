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
        public ActionResult<IEnumerable<ClienteModel>> Post(ClienteModel Cliente)
        {
            var clienteServico1 = new ClienteServicoModel();
            var clienteServico2 = new ClienteServicoModel();
            var cliente = new ClienteModel()
            {
                NomeEmpresa = "Teste",
                NomeContato = "Teste",
                Telefone = "Teste",
                Email = "Teste",
                ConteudoConversa = "Teste",
                DataHoraConversa = DateTime.Now
            };

            var servico1 = new ServicoModel()
            {
                NomeServico = "Teste 1"
            };

            var servico2 = new ServicoModel()
            {
                NomeServico = "Teste 2"
            };

            clienteServico1.Cliente = cliente;
            clienteServico1.Servico = servico1;

            clienteServico2.Cliente = cliente;
            clienteServico2.Servico = servico2;

            cliente.ClienteServico = new List<ClienteServicoModel>();
            cliente.ClienteServico.Add(clienteServico1);
            cliente.ClienteServico.Add(clienteServico2);

            _context.Clientes.Add(cliente);
            _context.Servicos.Add(servico1);
            _context.Servicos.Add(servico2);

            _context.SaveChanges();

            return _context.Clientes.ToList();
        }

        [HttpGet("Relatorio/{tipo}")]
        public ActionResult<IEnumerable<ClienteModel>> Get(char tipo)
        {
            var clientes = _context.Clientes.ToList();
            clientes.ForEach(x =>
            {
                x.ClienteServico = _context.ClientesServicos.Where(m => m.ClienteId == x.ClienteId).ToList();
            });
            clientes.ForEach(x =>
            {
                x.ClienteServico.ForEach(cs =>
                {
                    cs.Servico = _context.Servicos.Where(s => s.ServicoId == cs.ServicoId).First();
                });
            });
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
            return clientes.First();
        }

        private List<ClienteModel> ValorizarServico(List<ClienteModel> clientes)
        {
            // clientes.ForEach(x =>
            // {
            //     x.Servico = _context.ServicoModel.Where(a => a.ServicoId == x.ServicoId).First();
            // });

            return clientes;
        }

        [HttpDelete("{clienteId}")]
        public void Delete(int clienteId)
        {
            _context.Clientes.Remove(_context.Clientes.Where(x => x.ClienteId == clienteId).First());
            _context.SaveChanges();
        }

        [HttpGet]
        [Route("PesquisarServicos")]
        public ActionResult<IEnumerable<ServicoModel>> PesquisarServicos()
        {
            var a = _context.Servicos.ToList();
            return a;
        }

        [HttpGet("Inicializar")]
        public void Inicializar()
        {
            _context.Servicos.AddRange(
                new ServicoModel("Teste 1"),
                new ServicoModel("Teste 2"),
                new ServicoModel("Teste 3"),
                new ServicoModel("Teste 4"),
                new ServicoModel("Teste 5"),
                new ServicoModel("Teste 6")
            );
            _context.SaveChanges();
        }
    }
}
