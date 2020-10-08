namespace backend.Models
{
    public class CountryUnit : BaseModel
    {
        public int Count { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}