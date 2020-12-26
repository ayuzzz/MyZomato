using System;

namespace CommonModels
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Rating { get; set; }
        public string Owner { get; set; }
        public int? OpeningHour { get; set; }
        public int? ClosingHour { get; set; }
        public string ContactNumber { get; set; }
    }
}
