using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class BuildingReadDto
    {
        public int Count { get; set; }
        public int BuildingId { get; set; }
    }

    public class BuildingCreateDto
    {
        [Required]
        public string Name { get; set; }
    }

    public class BuildingTypeReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Population { get; set; }
        public int Units { get; set; }
        public int CoralPerTurn { get; set; }
    }
}