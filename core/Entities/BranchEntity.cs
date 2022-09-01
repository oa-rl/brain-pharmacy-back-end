namespace Core.Entities
{
    public class BranchEntity: BaseEntity
    {
        public int CompanyId { get; set; }
        public CompanyEntity? Company { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
