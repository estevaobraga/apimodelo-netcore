using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apimodelo.netcore.domain.domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apimodelo.netcore.presentation.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuario;

        public UsuarioController(IUsuarioRepository _usuario)
        {
            this._usuario = _usuario;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _usuario.AllAsync());
        }
    }
}