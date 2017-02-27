using System.ComponentModel.DataAnnotations.Schema;

namespace Leisurebooker.Business.Domain
{
    public class AdditionalInfo : Entity
    {
        public AdditionalInfoType Type { get; set; }

        public string Value { get; set; }

        public int BranchId { get; set; }
    }
}