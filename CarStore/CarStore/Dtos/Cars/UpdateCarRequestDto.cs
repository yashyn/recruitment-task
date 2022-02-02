using Cars.Domain.Models;

namespace CarStore.Api.Dtos.Cars
{
    public class UpdateCarRequestDto
    {
        public Guid Id { get; set; }
        public string Vin { get; set; }
        public CarType Type { get; set; }
    }
}
