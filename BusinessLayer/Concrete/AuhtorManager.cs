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
    public class AuhtorManager : IAuthorService
    {
        IAuthorDal _authorDal;
        public AuhtorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        public void AuthorAdd(Author author)
        {
            _authorDal.Insert(author);
        }

        public void AuthorDelete(Author author)
        {
            _authorDal.Delete(author);
        }

        public void AuthorUpdate(Author author)
        {
            _authorDal.Update(author);
        }

        public Author GetById(int id)
        {
            return _authorDal.Get(x => x.AuthorID == id);
        }

        public List<Author> GetList()
        {
            return _authorDal.List();
        }
    }
}
