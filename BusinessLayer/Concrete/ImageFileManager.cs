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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;
        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }
        public void AddImageFile(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public void DeleteImageFile(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public ImageFile GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }

        public void UpdateImageFile(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
