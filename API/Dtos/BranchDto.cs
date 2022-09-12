namespace API.Dtos
{
    public class BranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public int CompanyId { get; set; }
        public CompanyDto? Company { get; set; }
    }
}
