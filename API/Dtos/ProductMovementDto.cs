namespace API.Dtos
{
    public class ProductMovementDto
    {
        public int Id { get; set; }
        public int ProductCombinationId { get; set; }
        public ProductCombinationDto? ProductCombination { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public int OperationTypeId { get; set; }
    }
}
