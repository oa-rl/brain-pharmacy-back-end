using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "inv_product_movement")]
    public class ProductMovementEntity: BaseEntity
    {
        public int ProductCombinationId { get; set; }
        public virtual ProductCombinationEntity? ProductCombination { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime MovementDate { get; set; } =DateTime.UtcNow;
        public int Quantity { get; set; }
        public int OperationTypeId { get; set; }
        public virtual OperationTypeEntity? Operationtype { get; set; }
        public int? SaleInvoiceId { get; set; }
        public virtual SaleInvoiceEntity? SaleInvoice { get; set; }
    }
}
