using System;

namespace Leisurebooker.Business.Domain
{
    public class Message : IntEntity
    {
        //Aan welke reservatie hangt dit,

        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}