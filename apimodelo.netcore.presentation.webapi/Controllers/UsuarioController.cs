using System.Threading.Tasks;
using apimodelo.netcore.domain.domain.Interfaces;
using apimodelo.netcore.domain.domain.Models;
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

        /// <summary>
        /// Carregar todos os usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _usuario.AllAsync());
        }

        /// <summary>
        /// Criar um novo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            return Ok(await _usuario.SaveAsync(usuario));
        }

        /// <summary>
        /// Atualizar um usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(Usuario usuario)
        {
            return Ok(await _usuario.UpdateAsync(usuario));
        }

        /// <summary>
        /// Deletar um usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(Usuario usuario)
        {
            await _usuario.DeleteAsync(usuario);
            return Ok();
        }
    }
}