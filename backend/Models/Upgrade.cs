namespace backend.Models
{
    public class Upgrade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CoralBonus { get; set; }
        public int DefenseBonus { get; set; }
        public int AttackBonus { get; set; }
        public int TaxBonus { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}