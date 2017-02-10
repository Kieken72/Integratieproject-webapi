using Leisurebooker.Business.Domain;

namespace WebApi.Models.Dto
{
    public class AdditionalInfoDto
    {
        public int Id { get; set; }
        public AdditionalInfoType Type { get; set; }
        public string Value { get; set; }

        public int BranchId { get; set; }
    }
}