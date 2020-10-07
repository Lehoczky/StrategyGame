using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UnitReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int CostPerTurn { get; set; }
        public int CoralPerTurn { get; set; }
    }

    public class UnitCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
    }
}