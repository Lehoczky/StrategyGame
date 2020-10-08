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
}