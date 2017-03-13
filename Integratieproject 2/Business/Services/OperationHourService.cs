using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class OperationHourService : Service<OperationHours>
    {
        public OperationHourService() : base(new OperationHourRepository()) { }
    }
}