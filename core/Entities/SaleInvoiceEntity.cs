using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "sale_invoice")]
    public class SaleInvoiceEntity: BaseEntity
    {
        public string Authorization { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public CustomerEntity?  Customer { get; set; }

    }
}
