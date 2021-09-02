using System;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class AddVehicleDto
    {
        public string RegNum { get; set; }

        [Required (ErrorMessage = "Name of brand is missing")]
        public string Brand { get; set; }

        [Required (ErrorMessage = "Description of model is missing")]
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string FuelType { get; set; }
        public string GearType { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
    }
}