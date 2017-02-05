namespace Leisurebooker.Business.Domain
{
    public class Review : Entity
    {
        //Koppel aan reservatie


        public string Text { get; set; }
        public bool Public { get; set; }
        
        //Verschillende factoren? (Ja / Nee?)
    }
}