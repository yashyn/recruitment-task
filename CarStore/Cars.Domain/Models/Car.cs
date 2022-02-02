namespace Cars.Domain.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Vin { get; set; }
        public CarType Type { get; set; }
    }
}
