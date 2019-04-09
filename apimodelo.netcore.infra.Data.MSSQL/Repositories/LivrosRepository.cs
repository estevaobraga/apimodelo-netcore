using apimodelo.netcore.domain.domain.Interfaces;
using apimodelo.netcore.domain.domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace apimodelo.netcore.infra.Data.MSSQL.Repositories
{
    public class LivrosRepository : GenericRepository<Livros>, ILivrosRepository
    {
        public LivrosRepository(Context.Context context) : base (context)
        {
        }
    }
}
