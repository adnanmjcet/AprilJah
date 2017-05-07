﻿using BusinessLayer.Interface;
using CommonLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Implementation;
using DataAccessLayer.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class CategoryBs : ICategory
    {
        private readonly IGenericPattern<Category> _Category;
        //private readonly CategoryModel _CategoryModel;


        public CategoryBs()
        {
            _Category = new GenericPattern<Category>();
            //_CategoryModel = new CategoryModel();
        }

        public List<CategoryModel> CategoryList()
        {
            return _Category.GetAll().Where(x => x.IsDelete == false).Select(x => new CategoryModel
            {
                Id = x.Id,
                Name = x.Name,
                IsDelete = x.IsDelete,
                CreatedDate = x.CreatedDate
            }).ToList();
        }

        public CategoryModel GetById(int id)
        {
            return _Category.GetAll().Where(x => x.Id == id).Select(x => new CategoryModel
            {
                Id = x.Id,
                Name = x.Name,
                IsDelete = x.IsDelete,
                CreatedDate = x.CreatedDate
            }).FirstOrDefault();
        }

        public CategoryModel GetCategory(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public int Save(CategoryModel model)
        {
            Category _tbl_category = new Category(model);
            if (model.Id != null && model.Id != 0)
            {
                _Category.Update(_tbl_category);

            }
            else
            {
                _tbl_category.IsDelete = false;
                _tbl_category.CreatedDate = System.DateTime.Now;
                _Category.Insert(_tbl_category);
            }

            return _tbl_category.Id;
        }
    }
}