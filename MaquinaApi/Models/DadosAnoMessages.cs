namespace MaquinaApi.Models
{
    public class DadosAnoMessages
    {
        public long Id { get; set; }
        public required float price { get; set; }
        public required int month { get; set; }
        public required int year { get; set; }
    }
}
