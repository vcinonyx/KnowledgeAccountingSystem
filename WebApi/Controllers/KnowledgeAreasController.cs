using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Errors;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    public class KnowledgeAreasController : BaseApiController
    {
        private readonly IKnowledgeAreaService _knowledgeAreaService;

        public KnowledgeAreasController(IKnowledgeAreaService knowledgeAreaService)
        {
            _knowledgeAreaService = knowledgeAreaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnowledgeAreaDTO>>> Get()
        {
            var knowledgeAreas =  await _knowledgeAreaService.GetAllAsync();
            return Ok(knowledgeAreas);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KnowledgeAreaDTO>> GetById(int Id)
        {
            var knowledgeArea = await _knowledgeAreaService.GetByIdAsync(Id);

            if (knowledgeArea == null) return NotFound(new ApiResponse(404));
            
            return Ok(knowledgeArea);
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _knowledgeAreaService.DeleteByIdAsync(Id);
            return Ok();
        }

        [HttpGet("{Id}/skills")]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetSkills(int Id)
        {
            var skills = await _knowledgeAreaService.GetSkillsByKnowledgeAreaId(Id);
            return Ok(skills);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Post([FromQuery] string knowledgeAreaName)
        {
            await _knowledgeAreaService.AddAsync(new KnowledgeAreaDTO { Name = knowledgeAreaName});
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(KnowledgeAreaDTO model)
        {
            await _knowledgeAreaService.UpdateAsync(model);
            return Ok();
        }

        [HttpPost("{Id}/skills")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Post(int Id, [FromQuery] string skillName)
        {
            await _knowledgeAreaService.AddSkillToKnowledgeAreaAsync(Id, new SkillDTO { Name = skillName, KnowledgeAreaId = Id });
            return Ok();
        }
    }
}
