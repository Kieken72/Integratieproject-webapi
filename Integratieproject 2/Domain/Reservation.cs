using System;

namespace Leisurebooker.Business.Domain
{
    public class Reservation : IntEntity
    {
        public int AmountOfPersons { get; set; }
        public DateTime DateTime { get; set; }
        //vermoedelijke einddatum?

        //welke zaal
        //welke tafel koppelt backend..?

        //Wie heeft reservatie gemaakt

        //Gast


        public bool Cancelled { get; set; }
    }
}