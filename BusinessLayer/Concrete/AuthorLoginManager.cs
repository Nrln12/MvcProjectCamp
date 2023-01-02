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
    public class AuthorLoginManager : IAuthorLoginService
    {
        IAuthorDal _authordal;
        public AuthorLoginManager(IAuthorDal authorDal)
        {
            _authordal = authorDal;
        }
        public Author GetAuthor(string email, string password)
        {
            return _authordal.Get(x => x.AuthorEmail == email && x.AuthorPassword == password);
        }
    }
}
