using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories{
    public class SnapshotRepository : Repository<Snapshot>{
        public SnapshotRepository() : base(ContextFactory.GetContext()) { }
        
        public override Snapshot Create(Snapshot entity)
        {
            this.context.Snapshots.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public override IEnumerable<Snapshot> Read(bool eager = false)
        {
            if (eager)
            {
                return this.context.Snapshots
                    .Include(s => s.ChatMessages)
                    .Include(sc => sc.SessionCards)
                    .AsEnumerable();
            }
            return this.context.Snapshots.AsEnumerable();
        }

        public override Snapshot Read(int id, bool eager = false)
        {
            if (eager)
            {
                return this.context.Snapshots
                    .Include(s => s.ChatMessages)
                    .Include(sc => sc.SessionCards)
                    .FirstOrDefault(st => st.Id == id);
            }
            return this.context.Snapshots.Find(id);
        }

        public override void Update(Snapshot entity)
        {
            this.context.Snapshots.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id)
        {
            this.context.Snapshots.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
