using System;
namespace API.Dtos
{
	public class ProductCombinationDto
	{
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public double AmountSize { get; set; }
        public int MedicalHouseId { get; set; }
        public int SaleForId { get; set; }
        public int AmountSale { get; set; }
        public double Price { get; set; }
    }
}

