namespace backend.Models
{
    public class Upgrade : BaseModel
    {
        public string Name { get; set; }
        public int CoralBonus { get; set; }
        public int DefenseBonus { get; set; }
        public int AttackBonus { get; set; }
        public int TaxBonus { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}