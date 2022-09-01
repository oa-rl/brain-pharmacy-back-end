using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SatisfactionSurveyController : BaseController
    {
        private readonly IGenericRepository<SatisfactionSurveyEntity> _satisfactionSurveyEntity;

        public SatisfactionSurveyController(IGenericRepository<SatisfactionSurveyEntity> satisfactionSurveyEntity)
        {
            _satisfactionSurveyEntity = satisfactionSurveyEntity;
        }

        [HttpPost]
        public async Task<ActionResult<SatisfactionSurveyEntity>> PostSatisfactionSurvey([FromBody] SatisfactionSurveyEntity satisfactionSurvey)
        {
            var save = await _satisfactionSurveyEntity.Add(satisfactionSurvey);
            return Ok(save);
        }
    }
}
