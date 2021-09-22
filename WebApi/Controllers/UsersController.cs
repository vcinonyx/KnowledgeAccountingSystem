using BLL.DTOs;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Errors;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserSkillService _userSkillService;
        private readonly IAccountService _accountService;

        public UsersController(IAccountService accountService, IUserSkillService userSkillService)
        {
            _userSkillService = userSkillService;
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _accountService.GetAllUsersAsync();
            
            if (users.Count() == 0) return NotFound(new ApiResponse(404));

            return Ok(users);
        }

        [HttpGet("{role}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByRole(string role)
        {   
            var users = await _accountService.GetUsersByRoleAsync(role);
            
            if (users.Count() == 0) return NotFound(new ApiResponse(404));
           
            return Ok(users);
        }

        [HttpGet("programmer")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<ProgrammerDTO>>> GetProgrammers()
        {
            var programmers = await _userSkillService.GetAllProgrammersWithSkillsAsync();
            
            if (programmers.Count() == 0) return NotFound(new ApiResponse(404));

            return Ok(programmers);
        }

        [HttpGet("programmer/filter")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<ProgrammerDTO>>> GetProgrammersByFilter([FromQuery] ProgrammerFilterModel filter)
        {
            var programmers = await _userSkillService.GetProgrammersByFilter(filter); 
            
            if (programmers.Count() == 0) return NotFound(new ApiResponse(404));

            var result = new PagedCollectionResponse<ProgrammerDTO>();
            result.Items = programmers;

            return Ok(result);
        }

        [HttpGet("programmer/report")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<ProgrammerDTO>>> GenerateReport([FromQuery] IEnumerable<string> emails)
        {
            var programmers = await _userSkillService.GetAllProgrammersWithSkillsAsync();
            var result = programmers.Where(x => emails.Contains(x.User.Email));

            if (result == null) return NotFound(new ApiResponse(404));

            return Ok(result);
        }
    }
}
