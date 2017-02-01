using System.Collections.Generic;

namespace Leisurebooker.Business.Domain
{
    public class Room : GuidEntity
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }

        //Dimensions for visualisation
        public int Width { get; set; }
        public int Height { get; set; }

        public ICollection<Space> Spaces { get; set; } 

    }
}