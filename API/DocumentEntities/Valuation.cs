using System;

namespace API.DocumentEntities
{
    public class Valuation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Status { get; set; }
        public DateTime ValuationDate { get; set; }
        public string ValuationType { get; set; }
        public int Value { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}