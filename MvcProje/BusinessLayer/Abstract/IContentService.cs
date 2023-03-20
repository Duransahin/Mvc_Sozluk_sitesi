using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IContentService
    {
        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id);
        List<Content> GetListById(int id);//bu bana id'ye göre bütün veriyi verecek listeleme. Burada verdiğimiz id bizim başlık id'miz olacak bunun bütün içeriklerini getiri.
        void ContentAdd(Content content);
        void ContentDelet(Content content);
        void ContentUpdate(Content content);
        Content GetById(int id);
    }
}
