﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        [StringLength(50)]
        public string AuthorFirstName { get; set; }

        [StringLength(50)]
        public string AuthorLastName { get; set; }

        [StringLength(250)]
        public string AuthorImage { get; set; }

        [StringLength(100)]
        public string AuhtorAbout { get; set; }

        [StringLength(50)]
        public string AuthorTitle { get; set; }

        [StringLength(200)]
        public string AuthorEmail { get; set; }

        [StringLength(200)]
        public string AuthorPassword { get; set; }

        public bool AuthorStatus { get; set; }
       public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
