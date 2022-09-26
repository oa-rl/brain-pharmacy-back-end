using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "sale_invoice")]
    public class SaleInvoiceEntity: BaseEntity
    {
        public string Authorization { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public virtual CustomerEntity?  Customer { get; set; }
        public virtual List<SaleInvoiceDetailsEntity>? SaleInvoiceDetails { get; set; }
        public int UserId { get; set; }
        public virtual UserEntity? User { get; set; }

    }
}
