namespace Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime? ManufactureYear { get; set; }
        public int? Capacity { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public string EnginePower { get; set; }
    }
}
