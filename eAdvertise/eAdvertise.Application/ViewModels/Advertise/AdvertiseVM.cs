using eAdvertise.Application.DTOs.Advertise;
using System;
using System.Collections.Generic;

namespace eAdvertise.Application.ViewModels.Advertise
{
    public class AdvertiseVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsPremium { get; set; }
        public List<ImageDto> Images { get; set; }
        public string Mileage { get; set; }
        public string InternalStorage { get; set; }
    }
}
