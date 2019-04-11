using apimodelo.netcore.domain.domain.Models;
using System.Threading.Tasks;

namespace apimodelo.netcore.domain.domain.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<bool> UsuarioExiste(Usuario usuario);
    }
}
