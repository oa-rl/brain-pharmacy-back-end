using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "inv_size")]
    public class SizeEntity : BaseEntity
    {
        public string Name { get; set; } = "";
    }
}
