using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leisurebooker.Business.Domain
{
    //Makkelijk zoekbaar op adress!!! Index? + Makkelijk zoekbaar van plek vrij!
    public class Branch : GuidEntity
    {
        public string Name { get; set; }
        public Adress Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<Room> Rooms { get; set; } 

    }
}
