namespace backend.Models
{
    public class Building : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Population { get; set; }
        public int Units { get; set; }
        public int CoralPerTurn { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string StatImage { get; set; }
    }
}