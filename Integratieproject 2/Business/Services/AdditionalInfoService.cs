using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class AdditionalInfoService : Service<AdditionalInfo>
    {
        public AdditionalInfoService() : base(new AdditionalInfoRepository()) { }
    }
}