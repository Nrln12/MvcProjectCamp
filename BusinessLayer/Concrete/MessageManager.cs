﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageID == id && x.IsDraft == false);
        }

        public Message GetDraftById(int id)
        {
            return _messageDal.Get(x => x.MessageID == id && x.IsDraft == true);
        }

        public List<Message> GetListDraft(string p)
        {
            return _messageDal.List(x => x.IsDraft == true && x.DeleteStatus==false && x.SenderMail==p);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x=>x.RececiverMail== p && x.DeleteStatus==false);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.IsDraft==false && x.DeleteStatus==false); 
        }

        public List<Message> GetTrashBin(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.DeleteStatus==true);
        }

        public List<Message> GetUnreadMessages(string p)
        {
            return _messageDal.List(x => x.RececiverMail == p && x.MessageStatus == false);
        }

       

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

    }
}
