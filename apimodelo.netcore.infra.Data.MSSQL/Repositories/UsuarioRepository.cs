using apimodelo.netcore.domain.domain.Interfaces;
using apimodelo.netcore.domain.domain.Models;

namespace apimodelo.netcore.infra.Data.MSSQL.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context.Context context) : base (context)
        {
        }
    }
}
