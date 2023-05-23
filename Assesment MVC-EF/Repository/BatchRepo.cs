using Assesment_MVC_EF.Context;
using Assesment_MVC_EF.Models;

namespace Assesment_MVC_EF.Repository
{
    public class BatchRepo : BatchInterface
    {

        UserDbContext _db;
        public BatchRepo(UserDbContext db)
        {
            _db = db;
        }
        public Batch Create(Batch batch)
        {
            _db.Batches.Add(batch);
            _db.SaveChanges();
            return batch;
        }



        public int Edit(int id, Batch batch)
        {
            Batch obj = GetBatchById(id);
            if (obj != null)
            {
                foreach (Batch temp in _db.Batches)
                {
                    if (temp.BatchId == id)
                    {
                        temp.StartDate = batch.StartDate;
                        temp.BatchName = batch.BatchName;
                        temp.Trainer = batch.Trainer;
                    }
                }
                _db.SaveChanges();
            }
            return 1;
        }



        public Batch GetBatchById(int id)
        {
            return _db.Batches.FirstOrDefault(x => x.BatchId == id);
        }



        public List<Batch> GetBatches()
        {
            return _db.Batches.ToList();
        }
    }
}

