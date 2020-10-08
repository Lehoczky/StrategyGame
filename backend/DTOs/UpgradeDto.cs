using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UpgradeReadDto
    {
        public int UpgradeId { get; set; }
    }

    public class UpgradeCreateDto
    {
        [Required]
        public string Name { get; set; }
    }

    public class UpgradeTypeReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CoralBonus { get; set; }
        public int DefenseBonus { get; set; }
        public int AttackBonus { get; set; }
        public int TaxBonus { get; set; }
    }
}