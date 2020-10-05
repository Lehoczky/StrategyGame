namespace backend.DTOs
{
    public class UpgradeReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CoralBonus { get; set; }
        public int DefenseBonus { get; set; }
        public int AttackBonus { get; set; }
        public int TaxBonus { get; set; }
    }
}