using System.Collections.Generic;

namespace Leisurebooker.Business.Domain
{
    public class Room : Entity
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int BranchId { get; set; }
        public ICollection<Space> Spaces { get; set; }

        public Room()
        {
            Enabled = true;
        }
    }
}