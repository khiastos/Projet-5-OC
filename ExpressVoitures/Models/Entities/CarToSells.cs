namespace ExpressVoitures.Models.Entities
{
    public class CarToSells
    {
        public int ID { get; set; }
        public string Price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Finish { get; set; }
        public string SellingDate { get; set; }
        public bool IsAvailable { get; set; } = true;

    }
}
