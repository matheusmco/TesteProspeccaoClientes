using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteProspeccaoClientes.Data.Dtos;
using TesteProspeccaoClientes.Data.Models;

namespace TesteProspeccaoClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private Context _context;
        public ClienteController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<ClienteDto> Post(ClienteDto ClienteDto)
        {
            var Cliente = new ClienteModel()
            {
                ClienteId = ClienteDto.ClienteId,
                NomeEmpresa = ClienteDto.NomeEmpresa,
                NomeContato = ClienteDto.NomeContato,
                Telefone = ClienteDto.Telefone,
                Email = ClienteDto.Email,
                ConteudoConversa = ClienteDto.ConteudoConversa,
                DataHoraConversa = DateTime.Now
            };

            if (Cliente.ClienteId > 0)
            {
                _context.Clientes.Update(Cliente);
            }
            else
            {
                _context.Clientes.Add(Cliente);
            }

            var listaClienteServicoAdd = new List<ClienteServicoModel>();
            var listaClienteServicoUpdate = new List<ClienteServicoModel>();
            foreach (ServicoDto ServicoDto in ClienteDto.Servicos)
            {
                var clienteServico = new ClienteServicoModel()
                {
                    ClienteId = Cliente.ClienteId,
                    ServicoId = ServicoDto.ServicoId
                };

                if (_context.ClientesServicos.Find(Cliente.ClienteId, ServicoDto.ServicoId) == null)
                {
                    listaClienteServicoAdd.Add(clienteServico);
                }
                else
                {
                    listaClienteServicoAdd.Add(clienteServico);
                }
            }

            _context.ClientesServicos.AddRange(listaClienteServicoAdd);
            _context.ClientesServicos.UpdateRange(listaClienteServicoUpdate);

            _context.SaveChanges();

            return _context.Clientes.Select(x => new ClienteDto()
            {
                ClienteId = x.ClienteId,
                NomeEmpresa = x.NomeEmpresa,
                NomeContato = x.NomeContato,
                Telefone = x.Telefone,
                Email = x.Email,
                ConteudoConversa = x.ConteudoConversa,
                DataHoraConversa = x.DataHoraConversa,
                Servicos = x.ClienteServico.Select(c => new ServicoDto()
                {
                    ServicoId = c.Servico.ServicoId,
                    NomeServico = c.Servico.NomeServico
                }).ToList()
            }).First();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteDto>> Get()
        {
            return _context.Clientes.Select(x => new ClienteDto()
            {
                ClienteId = x.ClienteId,
                NomeEmpresa = x.NomeEmpresa,
                NomeContato = x.NomeContato,
                Telefone = x.Telefone,
                Email = x.Email,
                ConteudoConversa = x.ConteudoConversa,
                DataHoraConversa = x.DataHoraConversa,
                Servicos = x.ClienteServico.Select(c => new ServicoDto()
                {
                    ServicoId = c.Servico.ServicoId,
                    NomeServico = c.Servico.NomeServico
                }).ToList()
            }).ToList();
        }

        [HttpGet("{clienteId}")]
        public ActionResult<ClienteDto> Get(int clienteId)
        {
            if (_context.Clientes.Find(clienteId) == null)
            {
                return BadRequest("Não foi encontrado nenhum cliente com esse ID");
            }

            return _context.Clientes.Select(x => new ClienteDto()
            {
                ClienteId = x.ClienteId,
                NomeEmpresa = x.NomeEmpresa,
                NomeContato = x.NomeContato,
                Telefone = x.Telefone,
                Email = x.Email,
                ConteudoConversa = x.ConteudoConversa,
                DataHoraConversa = x.DataHoraConversa,
                Servicos = x.ClienteServico.Select(c => new ServicoDto()
                {
                    ServicoId = c.Servico.ServicoId,
                    NomeServico = c.Servico.NomeServico
                }).ToList()
            }).Where(x => x.ClienteId == clienteId).First();
        }

        [HttpDelete("{clienteId}")]
        public void Delete(int clienteId)
        {
            _context.Clientes.Remove(_context.Clientes.Where(x => x.ClienteId == clienteId).First());
            _context.SaveChanges();
        }
    }
}
