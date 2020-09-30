using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        public List<Building> Buildings { get; set; }
        public List<Unit> Units { get; set; }
        public List<Upgrade> Upgrades { get; set; }
    }
}