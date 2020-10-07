namespace backend.Models
{
    public class Unit : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int CostPerTurn { get; set; }
        public int CoralPerTurn { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}