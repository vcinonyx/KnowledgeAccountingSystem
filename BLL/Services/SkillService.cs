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
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(SkillDTO model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new AccountingSystemException("Skill's name can't be empty or null");
            }

            var skill = _mapper.Map<Skill>(model);
            await _unitOfWork.SkillRepository.AddAsync(skill);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.SkillRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<SkillDTO>> GetAllAsync()
        {
            var skills = await _unitOfWork.SkillRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<SkillDTO>>(skills);
        }

        public async Task<SkillDTO> GetByIdAsync(int id)
        {
            var skill = await _unitOfWork.SkillRepository.GetByIdAsync(id);
            return _mapper.Map<SkillDTO>(skill);
        }

        public async Task UpdateAsync(SkillDTO model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new AccountingSystemException("Skill's name can't be empty or null");
            }

            var skill = _mapper.Map<Skill>(model);
            _unitOfWork.SkillRepository.Update(skill);
            await _unitOfWork.SaveAsync();
        }
    }
}
