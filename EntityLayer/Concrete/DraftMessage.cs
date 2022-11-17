﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DraftMessage
    {
        [Key]
        public int MessageID { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; }

        [StringLength(50)]
        public string RececiverMail { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        public string MessageContent { get; set; }

        public DateTime MessageDate { get; set; }
    }
}
