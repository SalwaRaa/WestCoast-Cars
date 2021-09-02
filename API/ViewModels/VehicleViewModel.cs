namespace API.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string RegNum { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string FuelType { get; set; }
        public string GearType { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
    }
}