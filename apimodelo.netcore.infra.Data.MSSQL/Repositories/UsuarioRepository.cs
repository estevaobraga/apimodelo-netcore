using System.Linq;
using System.Threading.Tasks;
using apimodelo.netcore.domain.domain.Interfaces;
using apimodelo.netcore.domain.domain.Models;

namespace apimodelo.netcore.infra.Data.MSSQL.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly Context.Context context;

        public UsuarioRepository(Context.Context context) : base (context)
        {
            this.context = context;
        }

        public async Task<bool> UsuarioExiste(Usuario usuario)
        {
            var usuardb = context.Usuario.Where(x => x.Login.Equals(usuario.Login) && x.Senha.Equals(usuario.Senha));

            return usuardb.Any();
        }
    }
}
