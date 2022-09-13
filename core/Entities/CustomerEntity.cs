using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "core_customer")]
    public class CustomerEntity: BaseEntity
    {
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string NIT { get; set; } = "C/F";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone1 { get; set; } = "";
        public string Phone2 { get; set; } = "";

    }
}
