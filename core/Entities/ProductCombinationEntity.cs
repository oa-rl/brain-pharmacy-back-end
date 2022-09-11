using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "inv_product_combination")]
    public class ProductCombinationEntity: BaseEntity
	{
		public int ProductId { get; set; }
		public int SizeId { get; set; }
		public double AmountSize { get; set; }
		public int MedicalHouseId { get; set; }
		public int SaleForId { get; set; }
		public int AmountSale { get; set; }
		public double Price { get; set; }
	}
}

