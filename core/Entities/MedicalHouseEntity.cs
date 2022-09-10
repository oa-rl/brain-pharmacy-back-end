using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table(name: "inv_medical_house")]
    public class MedicalHouseEntity: BaseEntity
    {
        public string Name { get; set; } = "";
    }
}



//"ConnectionStrings": {
//    "conexionDatabase": "Server=localhost;Database=StreetPharmacy;Port=5432;User Id=postgres;Password=root"
//  },