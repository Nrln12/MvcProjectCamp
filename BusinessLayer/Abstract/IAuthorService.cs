using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetList();
        void AuthorAdd(Author author);
        void AuthorDelete(Author author);
        void AuthorUpdate(Author author);
        Author GetById(int id);
        Author GetByEmail(string p);
    }
}
