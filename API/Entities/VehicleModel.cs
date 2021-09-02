using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    //[Table("VehicleModel", Schema = "Vehicles")]
    public class VehicleModel
    {
        public int Id { get; set; }
        //[Column(TypeName = "VARCHAR(80)")]
        public string Description { get; set; }

        //Navigation properties
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}