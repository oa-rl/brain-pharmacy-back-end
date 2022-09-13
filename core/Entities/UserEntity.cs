using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "core_user")]
    public class UserEntity: BaseEntity
    {
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public int ProfileId { get; set; }
        public ProfileEntity? Profile { get; set; }
    }
}
