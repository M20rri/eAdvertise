using System.Text.Json.Serialization;

namespace eAdvertise.Application.DTOs.Advertise
{
    public class CarDto : AdvertiseDto
    {
        [JsonIgnore]
        public string Title
        {
            get
            {
                return $"{Brand} {Model} {Year}";
            }
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Mileage { get; set; }
        public string FuelType { get; set; }
        public int NoOfDoors { get; set; }
    }
}
