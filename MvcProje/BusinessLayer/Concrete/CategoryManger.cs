﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManger : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManger(ICategoryDal categoryDal)
        {
            _categorydal = categoryDal;
        }


        public void CategoryAdd(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDelet(Category category)
        {
            _categorydal.Delete(category);
            
        }

        public void CategoryUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categorydal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }



















        

    }
}
