namespace MaquinaApi.Models
{
    public class Drinks
    {
        public long Id { get; set; }
        public required string name { get; set; }
        public required float price { get; set; }
        public required int quant { get; set; }
        public required string image { get; set; }
    }
}
