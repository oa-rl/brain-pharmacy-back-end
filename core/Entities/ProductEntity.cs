using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "inv_product")]
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; } = "";
    }
}
