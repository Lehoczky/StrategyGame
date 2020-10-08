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
        public string Description { get; set; }
        public string Image { get; set; }
    }
}