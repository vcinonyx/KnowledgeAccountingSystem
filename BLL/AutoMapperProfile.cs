using AutoMapper;
using DAL.Entities;
using BLL.DTOs;
using System.Linq;
using DAL.Entities.Identity;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<KnowledgeArea, KnowledgeAreaDTO>()
                .ForMember(k => k.Skills, c => c.MapFrom(area => area.Skills.Select(x => new SkillDTO {
                    Id = x.Id,
                    KnowledgeAreaId = area.Id,
                    Name = x.Name,
                })))
                .ReverseMap();

            CreateMap<Skill, SkillDTO>()
                .ReverseMap();

            CreateMap<UserEvaluetedSkill, UserEvaluetedSkillDTO>()
                .ForMember(x => x.SkillName, c => c.MapFrom(x => x.Skill.Name))
                .ForMember(x => x.KnowledgeAreaName, c =>c.MapFrom(x => x.Skill.KnowledgeArea.Name));

            CreateMap<UserEvaluetedSkillDTO, UserEvaluetedSkill>();

            CreateMap<AppUser, UserDTO>();
        }
    }
}
