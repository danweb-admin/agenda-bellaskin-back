using System;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using Solucao.Application.Data.Entities;
using Solucao.Application.Helper;

namespace Solucao.Application.Data.Repositories
{
	public class HistoryRepository
	{
        public IUnitOfWork UnitOfWork => Db;
        protected readonly SolucaoContext Db;
        protected readonly DbSet<History> DbSet;

        public HistoryRepository(SolucaoContext _context)
        {
            Db = _context;
            DbSet = Db.Set<History>();
        }

        public async Task Add(string tableName, string operation, string userName, string message )
        {
            
            var history = new History
            {
                Id = Guid.NewGuid(),
                TableName = tableName,
                Operation = operation,
                UserName = userName,
                Message = message,
                OperationDate = Helpers.DateTimeNow()

            };

            DbSet.Add(history);
            await Db.SaveChangesAsync();

        }
    }
}

