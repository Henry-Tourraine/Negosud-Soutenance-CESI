using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegosudAPI.Service;
using NegosudAPI.Utils.DTO;
using System.Collections;

namespace NegosudAPI.Controllers
{
    [Route("[controller]")]
    public class UtilisateurController : Controller
    {
        // GET: UtilisateurController

        private ILogger _logger;
        private UtilisateurService _service;
        public UtilisateurController(ILogger logger, UtilisateurService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UtilisateurService>>> FindAllAsync()
        {
            var a = await _service.FindAll();
            return Ok(a);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UtilisateurService>> FindAsync(string id)
        {
            var a = await _service.Find(id);
            return Ok(a);
        }

        [HttpPost]
        public async Task<ActionResult<UtilisateurService>> CreateAsync(UtilisateurDTO utilisateur)
        {
            var a = await _service.Create(utilisateur);
            return Ok(a);
        }
        [HttpPut]
        public async Task<ActionResult<UtilisateurService>> PutAsync(UtilisateurDTO utilisateur)
        {
            await _service.Update(utilisateur);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            await _service.Delete(id);
            return NoContent();
        }

    }
}
