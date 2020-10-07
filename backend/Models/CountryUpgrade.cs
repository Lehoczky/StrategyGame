namespace backend.Models
{
    public class CountryUpgrade : BaseModel
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int UpgradeId { get; set; }
        public Upgrade Upgrade { get; set; }
    }
}