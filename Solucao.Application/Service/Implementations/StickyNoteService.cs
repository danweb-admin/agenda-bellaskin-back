using AutoMapper;
using Solucao.Application.Contracts;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Interfaces;
using Solucao.Application.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao.Application.Service.Implementations
{
    public class StickyNoteService : IStickyNoteService
    {
        private IStickyNoteRepository stickyNoteRepository;
        private readonly IMapper mapper;

        public StickyNoteService(IStickyNoteRepository _stickyNoteRepository, IMapper _mapper)
        {
            stickyNoteRepository = _stickyNoteRepository;
            mapper = _mapper;
        }
        public async Task<ValidationResult> Add(StickyNoteViewModel stickyNote)
        {
            stickyNote.Id = Guid.NewGuid();
            stickyNote.CreatedAt = DateTime.Now;
            var _stickyNote = mapper.Map<StickyNote>(stickyNote);
            return await stickyNoteRepository.Add(_stickyNote);
        }

        public async Task<IEnumerable<StickyNoteViewModel>> GetAll(DateTime date)
        {
            return mapper.Map<IEnumerable<StickyNoteViewModel>>(await stickyNoteRepository.GetAll(date));
        }

        public async Task<ValidationResult> Update(StickyNoteViewModel stickyNote)
        {
            stickyNote.UpdatedAt = DateTime.Now;
            var _stickyNote = mapper.Map<StickyNote>(stickyNote);

            return await stickyNoteRepository.Update(_stickyNote);
        }

        public async Task<ValidationResult> UpdateResolved(Guid stickyNotesId)
        {
            
            var stickyNote = await stickyNoteRepository.GetById(stickyNotesId);
            if (stickyNote == null)
                return new ValidationResult("Anotação não encontrada");

            stickyNote.Resolved = !stickyNote.Resolved;
            await stickyNoteRepository.Update(stickyNote);

            return ValidationResult.Success;
            
        }

        public async Task<ValidationResult> Remove(Guid stickyNotesId)
        {
            
            var stickyNote = await stickyNoteRepository.GetById(stickyNotesId);
            if (stickyNote == null)
                return new ValidationResult("Anotação não encontrada");

            stickyNote.Active = false;
            await stickyNoteRepository.Update(stickyNote);

            return ValidationResult.Success;
            
        }
    }
}
