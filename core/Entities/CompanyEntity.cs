using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class CompanyEntity : BaseEntity
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Nit { get; set; } = "";
    }
}
