using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Entities.Identity;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserSkillService : IUserSkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserSkillService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task AddAsync(UserEvaluetedSkillDTO model)
        {
            if (model == null)
                throw new ArgumentNullException("Invalid value", nameof(model));

            if (string.IsNullOrEmpty(model.UserId))
                throw new ArgumentException("Invalid value", nameof(model.UserId));

            if (model.SkillId == 0)
                throw new ArgumentException("Invalid value", nameof(model.SkillId));

            var skill = _mapper.Map<UserEvaluetedSkill>(model);

            await _unitOfWork.UserEvaluetedSkillRepository.AddAsync(skill);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var skill = await _unitOfWork.UserEvaluetedSkillRepository.GetByIdAsync(modelId);
            
            if (skill == null)
                throw new ArgumentException("Invalid value", nameof(modelId));

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

        public async Task UpdateAsync(UserEvaluetedSkillDTO model)
        {
            if (model == null)      
                throw new ArgumentNullException("Invalid value", nameof(model));
            
            if (string.IsNullOrEmpty(model.UserId))
                throw new ArgumentException("Invalid value", nameof(model.UserId));
            
            if (model.SkillId == 0)
                throw new ArgumentException("Invalid value", nameof(model.SkillId));

            _unitOfWork.UserEvaluetedSkillRepository.Update(_mapper.Map<UserEvaluetedSkill>(model));
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<UserEvaluetedSkillDTO>> GetUserSkillsByUserIdAsync(string userId)
        {
            var skills = await _unitOfWork.UserEvaluetedSkillRepository.GetSkillsByUserIdAsync(userId);
            
            return _mapper.Map<IEnumerable<UserEvaluetedSkillDTO>>(skills);
        }

        public async Task<IEnumerable<UserEvaluetedSkillDTO>> GetUserSkillsByUserEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) throw new ArgumentException("Parameter values is not valid", nameof(email));
            
            var skills = await GetUserSkillsByUserIdAsync(user.Id);
            
            return skills;
        }

        public async Task<IEnumerable<ProgrammerDTO>> GetAllProgrammersWithSkillsAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("Programmer");
            var programmers = new List<ProgrammerDTO>();

            foreach (var user in users)
            {
                programmers.Add(new ProgrammerDTO 
                { 
                    User = _mapper.Map<UserDTO>(user), 
                    Skills = await GetUserSkillsByUserIdAsync(user.Id) 
                });
            }

            return programmers;
        }

        public async Task<IEnumerable<ProgrammerDTO>> GetProgrammersByFilter(ProgrammerFilterModel filterModel)
        {
            var programmers = await GetAllProgrammersWithSkillsAsync();

            var result = programmers.Where(x => x.Skills.Select(x => x.SkillId)
                        .Intersect(filterModel.SkillIds).Count() == filterModel.SkillIds.Count())
                        .Skip((filterModel.Page - 1) * filterModel.Limit)
                        .Take(filterModel.Limit);

            return result;
        }

        public async Task<ProgrammerDTO> GetProgrammerByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var skills = await GetUserSkillsByUserEmailAsync(email);

            return new ProgrammerDTO { User = _mapper.Map<UserDTO>(user), Skills = skills };
        }
    }
}
