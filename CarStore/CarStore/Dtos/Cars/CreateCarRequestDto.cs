using Cars.Domain.Models;

namespace CarStore.Api.Dtos.Cars
{
    public class CreateCarRequestDto
    {
        public string Vin { get; set; }
        public CarType Type { get; set; }
    }
}
