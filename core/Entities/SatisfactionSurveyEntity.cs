using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "test_satisfaction_survey")]
    public class SatisfactionSurveyEntity: BaseEntity
    {
        public int IncidentNumber { get; set; }
        public bool Satisfied { get; set; }
        public string Comment { get; set; } = "";
    }
}
