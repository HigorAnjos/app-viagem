namespace Domain.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int? DriverVehicleId { get; set; }
        public int? PassengerId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string AuthorizedManagerCode { get; set; }
        public bool? CanceledByDriver { get; set; }
        public bool? CanceledByPassenger { get; set; }
        public decimal? Price { get; set; }
        public DateTime? TripDate { get; set; }
    }
}
