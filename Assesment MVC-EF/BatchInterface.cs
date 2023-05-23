using Assesment_MVC_EF.Models;
using System.Xml.Linq;

namespace Assesment_MVC_EF
{
 public interface BatchInterface
        {
            List<Batch> GetBatches();
            Batch Create(Batch batch);
            int Edit(int id, Batch batch);
            Batch GetBatchById(int id);
        }
    }

