namespace backend.Models
{
    public class Upgrade : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public class MudTractor : Upgrade
    {
        public int CoralBonus { get; set; }
        public MudTractor()
        {

        }
    }

    public class MudCombine : Upgrade
    {
        public int CoralBonus { get; set; }
        public MudCombine()
        {

        }
    }

    public class CoralWall : Upgrade
    {
        public int DefenseBonus { get; set; }
        public CoralWall()
        {

        }
    }

    public class SonarCannon : Upgrade
    {
        public int AttackBonus { get; set; }
        public SonarCannon()
        {

        }
    }

    public class UndergroundMartialArts : Upgrade
    {
        public int DefenseBonus { get; set; }
        public int AttackBonus { get; set; }
        public UndergroundMartialArts()
        {

        }
    }

    public class Alchemy : Upgrade
    {
        public int TaxBonus { get; set; }
        public Alchemy()
        {

        }
    }
}