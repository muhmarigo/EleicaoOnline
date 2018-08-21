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
    public class CandidatoController : ControllerBase
    {
        // POST: api/Partido
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Candidato model, [FromServices]CandidatoService service)
        {
           ;
            model = await service.CadastrarCandidato(model);
            return Created("", model);
        }        
    }
}
