using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao.Application.Data.Repositories
{
    public class EquipamentRepository : IEquipamentRepository
    {
        public IUnitOfWork UnitOfWork => Db;
        protected readonly SolucaoContext Db;
        protected readonly DbSet<Equipament> DbSet;

        public EquipamentRepository(SolucaoContext _context)
        {
            Db = _context;
            DbSet = Db.Set<Equipament>();
        }

        public virtual async Task<IEnumerable<Equipament>> GetAll(bool ativo)
        {
           var list = await Db.Equipaments.Select(e => new Equipament
           {
               Id = e.Id,
               Name = e.Name,
               Active = e.Active,
               Order = e.Order,
               EquipamentSpecifications = e.EquipamentSpecifications.Select(es => new EquipamentSpecifications
               {
                   Id = es.Id,
                   Name = es.Specification.Name,
                   Specification = es.Specification,
                   Active = es.Active,
                   EquipamentId = es.EquipamentId,
                   SpecificationId = es.SpecificationId
                   
               }).ToList()
           }).OrderBy(x => x.Order).ToListAsync();         


            return list;
        }

        public virtual async Task<IEnumerable<Equipament>> GetListById(List<Guid> guids)
        {
            return await Db.Equipaments.Include(x => x.EquipamentSpecifications)
                                        .ThenInclude(y => y.Specification)
                                        .Where(x => guids.Contains(x.Id)).OrderBy(x => x.Order).ToListAsync();
        }

        public virtual async Task<ValidationResult> Add(Equipament equipament)
        {
            try
            {

                Db.Equipaments.Add(equipament);
                await Db.SaveChangesAsync();
                return ValidationResult.Success;
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public virtual async Task<ValidationResult> Update(Equipament equipament)
        {
            try
            {
                Db.EquipamentSpecifications.RemoveRange(Db.EquipamentSpecifications.Where(x => x.EquipamentId == equipament.Id));
                DbSet.Update(equipament);
                await Db.SaveChangesAsync();
                return ValidationResult.Success;
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }

        }
    }
}
