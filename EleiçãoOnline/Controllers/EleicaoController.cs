using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EleicaoOnline.Models;
using EleicaoOnline.Services;
using EleicaoOnline.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EleicaoOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleicaoController : ControllerBase
    {
        // POST: api/Partido
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Eleicao model, [FromServices]EleicaoService service)
        {
            model = await service.CadastrarEleicao(model);
            return Created("", model);
        }

        [HttpGet("{id}/candidatos")]
        public ActionResult GetPoliticos([FromServices]EleicaoService service, int id, int page = 1, string search = "" )
        {
            return Ok(service.RetornaPoliticos(id, page, search));
        }

        [HttpGet("{id}/candidatos/maisvotados")]
        public ActionResult GetPoliticosMaisVotados([FromServices]EleicaoService service)
        {
            return Ok();
        }
    }
}
