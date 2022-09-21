namespace API.Dtos
{
    public class SaleInvoiceDto
    {
        public int Id { get; set; }
        public string Authorization { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public CustomerDto? Customer { get; set; }
        public List<SaleInvoiceDetailsDto>? SaleInvoiceDetails { get; set; }
    }
}
