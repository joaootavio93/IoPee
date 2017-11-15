namespace IoPee.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Humidity { get; set; }
        public int Temperature { get; set; }
        public bool Enable { get; set; }
        public bool Active { get; set; }
        public int DiaperId { get; set; }
        public Diaper Diaper { get; set; }
        public int BedId { get; set; }
        public Bed Bed { get; set; }
        public int MacId { get; set; }
        public Mac Mac { get; set; }
    }
}