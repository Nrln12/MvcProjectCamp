﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        List<Message> GetListDraft(string p);
        List<Message> GetUnreadMessages(string p);
        List<Message> GetTrashBin(string p);
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        Message GetById(int id);
        Message GetDraftById(int id);
        void MessageUpdate(Message message);
    }
}
