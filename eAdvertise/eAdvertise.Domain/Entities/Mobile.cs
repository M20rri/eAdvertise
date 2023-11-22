namespace eAdvertise.Domain.Entities
{
    public class Mobile : Advertise
    {
        public string InternalStorage { get; set; }
        public int NoOfSims { get; set; }
        public string CameraSpecs { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}
