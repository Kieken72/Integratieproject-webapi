using System;

namespace Leisurebooker.Business.Domain
{
    //Ofwel enkel een soort ID ofwel adhv GUID nog niet zeker
    

    public abstract class Entity
    {
        public virtual int Id { get; set; }
    }
}
