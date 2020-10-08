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
}