using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserSkillService : ICrud<UserEvaluetedSkillDTO>
    {
        Task<IEnumerable<UserEvaluetedSkillDTO>> GetUserSkillsByUserIdAsync(string userId);
    }
}
