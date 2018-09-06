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
    public class ServicoController : ControllerBase
    {
        private Context _context;
        public ServicoController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServicoDto>> Get()
        {
            return _context.Servicos.Select(x => new ServicoDto()
            {
                ServicoId = x.ServicoId,
                NomeServico = x.NomeServico
            }).ToList();
        }
    }
}
