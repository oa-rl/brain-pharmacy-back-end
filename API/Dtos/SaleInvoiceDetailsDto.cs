namespace API.Dtos
{
    public class SaleInvoiceDetailsDto
    {
        public int Id { get; set; }
        public int SaleInvoiceId { get; set; }
        public int ProductCombinationId { get; set; }
        public ProductCombinationDto? ProductCombination { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double PriceWithOutTax { get; set; }
        public double Tax { get; set; }
    }
}
