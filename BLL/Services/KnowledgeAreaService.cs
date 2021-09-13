using System;
using System.Collections.Generic;
using BLL.Interfaces;
using BLL.DTOs;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using BLL.Validation;

namespace BLL.Services
{
    public class KnowledgeAreaService : IKnowledgeAreaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public KnowledgeAreaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(KnowledgeAreaDTO model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new AccountingSystemException("Model name can't be empty or null");
            }

            var knowledgeArea = _mapper.Map<KnowledgeArea>(model);
            await _unitOfWork.KnowledgeAreaRepository.AddAsync(knowledgeArea);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddSkillToKnowledgeAreaAsync(int knowledgeAreaId, SkillDTO skillModel)
        {
            var skill = _mapper.Map<Skill>(skillModel);
            await _unitOfWork.SkillRepository.AddAsync(skill);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.KnowledgeAreaRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<KnowledgeAreaDTO>> GetAllAsync()
        {
            var knowledgeAreas =  await _unitOfWork.KnowledgeAreaRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<KnowledgeArea>, IEnumerable<KnowledgeAreaDTO>>(knowledgeAreas);
        }

        public async Task<KnowledgeAreaDTO> GetByIdAsync(int id)
        {
            var knowledgeArea = await _unitOfWork.KnowledgeAreaRepository.GetByIdAsync(id);
            return _mapper.Map<KnowledgeArea, KnowledgeAreaDTO>(knowledgeArea);
        }

        public async Task<IEnumerable<SkillDTO>> GetSkillsByKnowledgeAreaId(int knowledgeAreaId)
        {
            var skills = await _unitOfWork.KnowledgeAreaRepository.GetSkillsByKnowledgeAreaIdAsync(knowledgeAreaId);
            return _mapper.Map<IEnumerable<SkillDTO>>(skills);
        }

        public async Task UpdateAsync(KnowledgeAreaDTO model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new AccountingSystemException("Model name can't be empty or null");
            }

            var knowledgeArea = _mapper.Map<KnowledgeArea>(model);
            _unitOfWork.KnowledgeAreaRepository.Update(knowledgeArea);
            await _unitOfWork.SaveAsync();
        }
    }
}
