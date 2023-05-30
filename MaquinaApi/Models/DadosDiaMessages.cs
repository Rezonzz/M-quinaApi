﻿namespace MaquinaApi.Models
{
    public class DadosDiaMessages
    {
        public long Id { get; set; }
        public required int hour { get; set; }
        public required int day { get; set; }
        public required float price { get; set; }
        public required int month { get; set; }
        public required int year { get; set; }
    }
}
