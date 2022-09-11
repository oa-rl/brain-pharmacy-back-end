using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "core_branch")]
    public class BranchEntity: BaseEntity
    {
        public int CompanyId { get; set; }
        public CompanyEntity? Company { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
