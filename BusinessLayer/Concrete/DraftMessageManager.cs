using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DraftMessageManager : IDraftMessageService
    {
        IDraftMessageDal _draftDal;
        public DraftMessageManager(IDraftMessageDal draftMessageDal)
        {
            _draftDal = draftMessageDal;
        }

        public void Delete(DraftMessage draftMessage)
        {
            _draftDal.Delete(draftMessage);
        }

        public DraftMessage GetByID(int id)
        {
            return _draftDal.Get(x => x.MessageID == id);
        }

        public List<DraftMessage> GetList()
        {
            return _draftDal.List();
        }

        public void Insert(DraftMessage draftMessage)
        {
            _draftDal.Insert(draftMessage);
        }

        public void Update(DraftMessage draftMessage)
        {
            _draftDal.Update(draftMessage);
        }
    }
}
