using System.Threading.Tasks;
using apimodelo.netcore.domain.domain.Interfaces;
using apimodelo.netcore.domain.domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apimodelo.netcore.presentation.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LivroController : Controller
    {
        private readonly ILivrosRepository _livro;

        public LivroController(ILivrosRepository _livro)
        {
            this._livro = _livro;
        }

        /// <summary>
        /// Carregar todos os livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _livro.AllAsync());
        }

        /// <summary>
        /// Criar um novo livro
        /// </summary>
        /// <param name="livros"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Livros livro)
        {
            return Ok(await _livro.SaveAsync(livro));
        }

        /// <summary>
        /// Atualizar um livro
        /// </summary>
        /// <param name="livros"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(Livros livro)
        {
            return Ok(await _livro.UpdateAsync(livro));
        }

        /// <summary>
        /// Deletar um livro
        /// </summary>
        /// <param name="livros"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(Livros livro)
        {
            await _livro.DeleteAsync(livro);
            return Ok();
        }
    }
}