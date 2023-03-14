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
    public class WriterManger : IWriterSevice
    {
        IWriterDal _wirerDal;

        public WriterManger(IWriterDal writerDal)
        {
            _wirerDal = writerDal;
        }

        public Writer GetById(int id)
        {
            return _wirerDal.Get(x => x.WriterId == id);
        }

        public List<Writer> GetList()
        {
            return _wirerDal.List();
        }

        public void WriterAdd(Writer writer)
        {
            _wirerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _wirerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _wirerDal.Update(writer);
        }
    }
}
