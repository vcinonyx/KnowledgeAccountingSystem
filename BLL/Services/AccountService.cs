using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Validation;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
            ITokenService tokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<UserDTO> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            
            if (user == null)
            {
                throw new ArgumentException("No users with specified email");
            }

            return new UserDTO
            {
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user),
                DisplayName = user.DisplayName
            };
        }

        public async Task<bool> CkeckEmailExistsAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<UserDTO> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)  throw new UnauthorizedAccessException("User is not authorized");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded) throw new UnauthorizedAccessException("User is not authorized");

            return new UserDTO
            {
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user),
                DisplayName = user.DisplayName
            };
        }

        public async Task<UserDTO> Register(RegisterDTO registerDTO)
        {
            if (CkeckEmailExistsAsync(registerDTO.Email).Result)
            {
                throw new AccountingSystemException("Email adress is in use");
            }

            var user = new AppUser
            {
                DisplayName = registerDTO.DisplayName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            
            //if (!result.Succeeded) throw new exception;

            return new UserDTO
            {
                DisplayName = user.DisplayName,
                Token = await _tokenService.CreateTokenAsync(user),
                Email = user.Email
            };
        }

        public async Task<IEnumerable<UserDTO>> GetUsersByRoleAsync(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        //public async Task<IEnumerable<UserEvaluetedSkillDTO>> GetUserSkills(string email)
        //{

        //    var user = await _userManager.FindByEmailAsync(email);

        //    var skills = await _userSkillService.GetUserSkillsByUserIdAsync(user.Id);
            
        //    //if (skills == null)
        //    //{
        //    //    return NotFound(new ApiResponse(404));
        //    //}

        //    return skills;
        //}

        // move to user skill service;
        //public async Task AddSkillToUser(UserEvaluetedSkillDTO skillDTO)
        //{
        //    await _userSkillService.AddAsync(skillDTO);
        //}

        //public async Task UpdateUserSkill(UserEvaluetedSkillDTO skillDTO)
        //{
        //    await _userSkillService.UpdateAsync(skillDTO);
        //}
    }
}

