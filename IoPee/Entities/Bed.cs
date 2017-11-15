namespace IoPee.Entities
{
    public class Bed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}