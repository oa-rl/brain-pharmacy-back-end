using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "inv_medical_house")]
    public class MedicalHouseEntity: BaseEntity
    {
        public string Name { get; set; } = "";
    }
}
