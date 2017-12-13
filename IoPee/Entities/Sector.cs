using System.Collections.Generic;

namespace IoPee.Entities
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Bed> Beds { get; set; }
    }
}