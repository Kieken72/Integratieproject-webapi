using System.Data.Entity;

namespace Leisurebooker.DataAccess.EF
{
    public class Initialiser : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);
        }
    }
}
