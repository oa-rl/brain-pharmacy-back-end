using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "sale_invoice_details")]
    public class SaleInvoiceDetailsEntity: BaseEntity
    {
        public int SaleInvoiceId { get; set; }
        public virtual SaleInvoiceEntity? SaleInvoice { get; set; }
        public int ProductCombinationId { get; set; }
        public virtual ProductCombinationEntity? ProductCombination { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double PriceWithOutTax { get; set; }
        public double Tax { get; set; }
    }
}
