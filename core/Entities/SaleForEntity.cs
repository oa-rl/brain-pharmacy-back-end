using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "inv_sale_for")]
    public class SaleForEntity : BaseEntity
    {
        public string Name { get; set; } = "";
    }
}

