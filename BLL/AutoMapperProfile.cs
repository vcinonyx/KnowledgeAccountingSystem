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
                .ReverseMap();

            CreateMap<UserEvaluetedSkill, UserEvaluetedSkillDTO>()
                .ForMember(x => x.SkillName, c => c.MapFrom(x => x.Skill.Name))
                .ForMember(x => x.KnowledgeAreaName, c =>c.MapFrom(x => x.Skill.KnowledgeArea.Name));

            CreateMap<UserEvaluetedSkillDTO, UserEvaluetedSkill>();
        }
    }
}
