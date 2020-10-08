using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UnitReadDto
    {
        public int Count { get; set; }
        public int UnitId { get; set; }
    }

    public class UnitCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
    }
}