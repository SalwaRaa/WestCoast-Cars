using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    //[Table("Vehicle", Schema = "Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        //[Column(TypeName = "VARCHAR(10)")]
        public string RegNum { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        //[Column(TypeName = "SMALLINT")]
        public int ModelYear { get; set; }
        //[Column(TypeName = "VARCHAR(15)")]
        public string FuelType { get; set; }
        //[Column(TypeName = "VARCHAR(40)")]
        public string GearType { get; set; }
        //[Column(TypeName = "VARCHAR(30)")]
        public string Color { get; set; }
        public int Mileage { get; set; }
        
        //Navgation properties
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
        
        [ForeignKey("ModelId")]
        public virtual VehicleModel Model { get; set; }
    }
}