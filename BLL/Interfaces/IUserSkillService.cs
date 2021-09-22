using BLL.DTOs;
using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserSkillService : ICrud<UserEvaluetedSkillDTO>
    {
        Task<IEnumerable<UserEvaluetedSkillDTO>> GetUserSkillsByUserEmailAsync(string email);
        Task<IEnumerable<ProgrammerDTO>> GetAllProgrammersWithSkillsAsync();
        Task<IEnumerable<ProgrammerDTO>> GetProgrammersByFilter(ProgrammerFilterModel filterModel);
        Task<ProgrammerDTO> GetProgrammerByEmail(string email);
    }
}
