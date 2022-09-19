namespace API.Dtos
{
    public class ProductMovementDto
    {
        public int Id { get; set; }
        public int ProductCombinationId { get; set; }
        public ProductCombinationDto? ProductCombination { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public int OperationTypeId { get; set; }
        public OperationTypeDto? OperationType{ get; set; }
    }
}
