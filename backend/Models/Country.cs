using System.Collections.Generic;

namespace backend.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; }
        public int Pearls { get; set; }
        public int Coralls { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CountryBuilding> Buildings { get; set; }
        public virtual ICollection<CountryUnit> Units { get; set; }
        public virtual ICollection<CountryUpgrade> Upgrades { get; set; }
    }
}