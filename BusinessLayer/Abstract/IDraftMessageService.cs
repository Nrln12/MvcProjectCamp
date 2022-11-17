using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDraftMessageService
    {
        List<DraftMessage> GetList();
        void Insert(DraftMessage draftMessage);
        DraftMessage GetByID(int id);
        void Delete(DraftMessage draftMessage);
        void Update(DraftMessage draftMessage);
    }
}
