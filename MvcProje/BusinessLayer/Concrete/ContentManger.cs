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
    public class ContentManger : IContentService
    {
        IContentDal _contetDal;

        public ContentManger(IContentDal contetDal)
        {
            _contetDal = contetDal;
        }

        public void ContentAdd(Content content)
        {
            _contetDal.Insert(content);
        }

        public void ContentDelet(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string p )
        {
            return _contetDal.List(x=>x.ContentValue.Contains(p));
        }

        public List<Content> GetListById(int id)
        {
            return _contetDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contetDal.List(x => x.WriterId == id);
        }
    }
}
