using System;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using Solucao.Application.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solucao.Application.Data.Repositories
{
	public class TechnicalAttributesRepository
	{
        public IUnitOfWork UnitOfWork => Db;
        protected readonly SolucaoContext Db;
        protected readonly DbSet<TechnicalAttributes> DbSet;

        public TechnicalAttributesRepository(SolucaoContext _context)
        {
            Db = _context;
            DbSet = Db.Set<TechnicalAttributes>();
        }

        public async Task<IEnumerable<TechnicalAttributes>> Get()
        {
            return await Db.TechnicalAttributes.ToListAsync();
        }
    }
}

