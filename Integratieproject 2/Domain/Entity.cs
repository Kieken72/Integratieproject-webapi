using System;

namespace Leisurebooker.Business.Domain
{
    //Ofwel enkel een soort ID ofwel adhv GUID nog niet zeker

    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public abstract class IntEntity : IEntity<int>
    {
        public int Id { get; set; }
    }

    public abstract class GuidEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
