using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{

    public class ProgrammerFilterModel : BaseFilterModel
    {
        public IEnumerable<int> SkillIds { get; set; }
        public ProgrammerFilterModel()
        {
            Limit = 10;
        }
    }
}
