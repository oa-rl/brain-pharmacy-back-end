using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "core_profile")]
    public class ProfileEntity: BaseEntity
    {
        public string Name { get; set; } = "";
    }
}
