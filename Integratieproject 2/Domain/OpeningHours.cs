namespace Leisurebooker.Business.Domain
{
    public class OpeningHour : IntEntity
    {
        public Day Day { get; set; }

        //start eind uur?

        
    }

    public enum Day : byte
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}