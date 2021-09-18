using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserSkillService : IUserSkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserSkillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(UserEvaluetedSkillDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Invalid value", nameof(model));
            }

            if (string.IsNullOrEmpty(model.UserId))
            {
                throw new ArgumentException("Invalid value", nameof(model.UserId));
            }

            if (model.SkillId == 0)
            {
                throw new ArgumentException("Invalid value", nameof(model.SkillId));
            }

            var skill = _mapper.Map<UserEvaluetedSkill>(model);

            await _unitOfWork.UserEvaluetedSkillRepository.AddAsync(skill);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var skill = await _unitOfWork.UserEvaluetedSkillRepository.GetByIdAsync(modelId);
            if (skill == null)
            {
                throw new ArgumentException("Invalid value", nameof(modelId));
            }

            await _unitOfWork.UserEvaluetedSkillRepository.DeleteByIdAsync(modelId);
        }

        public async Task<IEnumerable<UserEvaluetedSkillDTO>> GetAllAsync()
        {
            var skills = await _unitOfWork.UserEvaluetedSkillRepository.GetAllWithDetailsAsync();

            return _mapper.Map<IEnumerable<UserEvaluetedSkillDTO>>(skills);
        }

        public async Task<UserEvaluetedSkillDTO> GetByIdAsync(int id)
        {
            var skill = await _unitOfWork.UserEvaluetedSkillRepository.GetByIdAsync(id);

            return _mapper.Map<UserEvaluetedSkillDTO>(skill);
        }

        public async Task<IEnumerable<UserEvaluetedSkillDTO>> GetUserSkillsByUserIdAsync(string userId)
        {
            var userSkills = await _unitOfWork.UserEvaluetedSkillRepository.GetSkillsByUserIdAsync(userId);

            return _mapper.Map<IEnumerable<UserEvaluetedSkillDTO>>(userSkills);
        }

        public async Task UpdateAsync(UserEvaluetedSkillDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Invalid value", nameof(model));
            }

            if (string.IsNullOrEmpty(model.UserId))
            {
                throw new ArgumentException("Invalid value", nameof(model.UserId));
            }

            if (model.SkillId == 0)
            {
                throw new ArgumentException("Invalid value", nameof(model.SkillId));
            }

            _unitOfWork.UserEvaluetedSkillRepository.Update(_mapper.Map<UserEvaluetedSkill>(model));
            await _unitOfWork.SaveAsync();
        }
    }
}
