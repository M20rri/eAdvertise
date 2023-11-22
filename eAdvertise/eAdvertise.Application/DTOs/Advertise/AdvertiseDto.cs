using System.Collections.Generic;

namespace eAdvertise.Application.DTOs.Advertise
{
    public class AdvertiseDto
    {
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public List<ImageDto> Images { get; set; }
        public bool IsPremium { get; set; }
    }
}
