using AutoMapper;
using DAL.Entities;
using BLL.DTOs;
using System.Linq;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<KnowledgeArea, KnowledgeAreaDTO>()
                .ForMember(k => k.SkillIds, c => c.MapFrom(area => area.Skills.Select(x => x.Id)))
                .ReverseMap();

            CreateMap<Skill, SkillDTO>()
                .ForMember(x => x.KnowledgeAreaName, c => c.MapFrom(x => x.KnowledgeArea.Name))
                .ReverseMap();
        }
    }
}
