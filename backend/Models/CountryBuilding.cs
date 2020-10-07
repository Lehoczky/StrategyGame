namespace backend.Models
{
    public class CountryBuilding : BaseModel
    {
        public int Count { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}