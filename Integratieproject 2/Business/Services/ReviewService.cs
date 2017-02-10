using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class ReviewService : Service<Review>
    {
        public ReviewService() : base(new ReviewRepository()) { }
    }
}