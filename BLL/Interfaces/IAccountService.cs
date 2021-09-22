using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> FindUserByEmailAsync(string email);
        Task<IEnumerable<UserDTO>> GetUsersByRoleAsync(string role);
        Task<bool> CkeckEmailExistsAsync(string email);
        Task<UserDTO> Login(LoginDTO loginDTO);
        Task<UserDTO> Register(RegisterDTO registerDTO);
    }
}
