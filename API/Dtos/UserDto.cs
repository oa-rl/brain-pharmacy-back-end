using Core.Entities;

namespace API.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public int ProfileId { get; set; }
        public ProfileEntity? Profile { get; set; }
    }
}
