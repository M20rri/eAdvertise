namespace eAdvertise.Domain.Entities
{
    public class Car : Advertise
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Mileage { get; set; }
        public string FuelType { get; set; }
        public int NoOfDoors { get; set; }
    }
}
