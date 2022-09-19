using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "inv_product_movement")]
    public class ProductMovementEntity: BaseEntity
    {
        public int ProductCombinationId { get; set; }
        public ProductCombinationEntity? ProductCombination { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public int OperationTypeId { get; set; }
    }
}
