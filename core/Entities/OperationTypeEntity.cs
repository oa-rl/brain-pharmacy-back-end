using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "inv_operation_type")]
    public class OperationTypeEntity: BaseEntity
    {
        public string Sign { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
