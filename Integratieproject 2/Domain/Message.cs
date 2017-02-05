using System;

namespace Leisurebooker.Business.Domain
{
    public class Message : Entity
    {
        //Aan welke reservatie hangt dit,

        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}