using System.Text.Json.Serialization;

namespace eAdvertise.Application.DTOs.Advertise
{
    public class MobileDto : AdvertiseDto
    {
        [JsonIgnore]
        public string Title
        {
            get
            {
                return $"{Brand} {Model} {Color}";
            }
        }
        public string InternalStorage { get; set; }
        public int NoOfSims { get; set; }
        public string CameraSpecs { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}
