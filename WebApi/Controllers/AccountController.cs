using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly IUserSkillService _userSkillService;

        public AccountController(IAccountService accountService, IUserSkillService userSkillService)        
        {
            _accountService = accountService;
            _userSkillService = userSkillService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _accountService.FindUserByEmailAsync(email);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            try
            {
                var result = await _accountService.Login(loginDTO);
                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new ApiResponse(401));
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (_accountService.CkeckEmailExistsAsync(registerDTO.Email).Result)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Email adress is in use" } });
            }

            var result = await _accountService.Register(registerDTO);

            return Ok(result);
        }

        [Authorize(Roles = "Programmer")]
        [HttpGet("skills")]
        public async Task<ActionResult<IEnumerable<UserEvaluetedSkillDTO>>> GetUserSkills()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var skills = await _userSkillService.GetUserSkillsByUserEmailAsync(email);
            if (skills == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok(skills);
        }

        [Authorize(Roles = "Programmer")]
        [HttpPost("skills")]
        public async Task<ActionResult> AddSkillToUser([FromBody] UserEvaluetedSkillDTO skillDTO)
        {
            await _userSkillService.AddAsync(skillDTO);
            return Ok();
        }

        [Authorize(Roles = "Programmer")]
        [HttpPut("skills")]
        public async Task<ActionResult> UpdateUserSkill([FromBody] UserEvaluetedSkillDTO skillDTO)
        {
            await _userSkillService.UpdateAsync(skillDTO);
            return Ok();
        }
    }
}
