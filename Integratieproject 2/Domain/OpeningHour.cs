namespace Leisurebooker.Business.Domain
{
    public class OpeningHour : Entity
    {
        public Day Day { get; set; }

        public int BranchId { get; set; }
        //start eind uur?
    }
}