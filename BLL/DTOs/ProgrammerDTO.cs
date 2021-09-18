using System.Collections.Generic;

namespace BLL.DTOs
{
    public class ProgrammerDTO
    {
        public UserDTO User { get; set; }
        public IEnumerable<UserEvaluetedSkillDTO> Skills { get; set; }
    }
}
