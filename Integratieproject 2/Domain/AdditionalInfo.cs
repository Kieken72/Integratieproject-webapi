namespace Leisurebooker.Business.Domain
{
    public class AdditionalInfo : IntEntity
    {
        public AdditionalInfoType Type { get; set; }
        public string Value { get; set; }
    }
}