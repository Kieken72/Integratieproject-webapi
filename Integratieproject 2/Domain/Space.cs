namespace Leisurebooker.Business.Domain
{
    public class Space : GuidEntity
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }

        //Iets voor type te bepalen

        public int Persons { get; set; }
        public int MinPersons { get; set; }

    }
}