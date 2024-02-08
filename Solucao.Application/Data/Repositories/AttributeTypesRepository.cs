using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using Solucao.Application.Data.Entities;

namespace Solucao.Application.Data.Repositories
{
	public class AttributeTypesRepository
    {
        public IUnitOfWork UnitOfWork => Db;
        protected readonly SolucaoContext Db;
        protected readonly DbSet<AttributeTypes> DbSet;

        public AttributeTypesRepository(SolucaoContext _context)
		{
            Db = _context;
            DbSet = Db.Set<AttributeTypes>();
        }

        public async Task<IEnumerable<AttributeTypes>> Get()
        {
            return await Db.AttributeTypes.ToListAsync();
        }
    }
}

