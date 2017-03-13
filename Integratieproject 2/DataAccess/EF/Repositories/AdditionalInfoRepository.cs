using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class AdditionalInfoRepository : Repository<AdditionalInfo>
    {
        public AdditionalInfoRepository(Context context) : base(context){}
        public AdditionalInfoRepository() : base(ContextFactory.GetContext()) {}

        public override AdditionalInfo Create(AdditionalInfo entity)
        {
            this.Context.AdditionalInfos.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public override AdditionalInfo Read(int id, bool eager = false)
        {
            return this.Context.AdditionalInfos.Find(id);
        }

        public override void Update(AdditionalInfo entity)
        {
            this.Context.AdditionalInfos.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var oh = Read(id);
            this.Context.AdditionalInfos.Remove(oh);
        }

        public override IEnumerable<AdditionalInfo> Read(bool eager = false)
        {
            return this.Context.AdditionalInfos.AsEnumerable();
        }
    }
}
