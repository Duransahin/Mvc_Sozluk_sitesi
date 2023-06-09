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
    public class ImageFileManger : IImageFileService
    {
        IImageFileDal _ımageDal;

        public ImageFileManger(IImageFileDal ımageDal)
        {
            _ımageDal = ımageDal;
        }

        public List<ImageFile> GetList()
        {
            return _ımageDal.List();
        }
    }
}
