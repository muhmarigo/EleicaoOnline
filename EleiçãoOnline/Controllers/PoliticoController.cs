using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EleicaoOnline.Services;
using EleicaoOnline.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EleicaoOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliticoController : ControllerBase
    {
        // POST: api/Partido
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Politico model, [FromServices]PoliticoService service)
        {
            model = await service.CadastrarPolitico(model);
            return Created("", model);
        }        
    }
}
