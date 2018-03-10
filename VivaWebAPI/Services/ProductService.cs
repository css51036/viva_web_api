using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VivaWebAPI.Models;
using VivaWebAPI.Class;
using System.Threading.Tasks;

namespace VivaWebAPI.Services
{
    public class ProductService
    {
        public  Category GetCategoryAsync(int category_id)
        {
            Category category = new Category();
            ReadFileService _fileService = new ReadFileService(category_id);

            IList<Product> productList =   _fileService.GetProductAsyn(true).Result;

            category._product = productList;

            if (category_id == (int)Constants.FILE_NAME.SOLVENTS)
            {
                category._eng_name = "SOLVENTS & SPECIALTY";
                category._thai_name = "SOLVENTS & SPECIALTY";
                category._id = 1;

                IList<SubCategory> listSubCategory = new List<SubCategory>();
                SubCategory SOLVENTS_LIQUID_CHEMICALS = new SubCategory();
                SOLVENTS_LIQUID_CHEMICALS._id = 1;
                SOLVENTS_LIQUID_CHEMICALS._eng_name = "SOLVENTS & LIQUID CHEMICALS";
                SOLVENTS_LIQUID_CHEMICALS._thai_name = "SOLVENTS & LIQUID CHEMICALS";
                listSubCategory.Add(SOLVENTS_LIQUID_CHEMICALS);

                SubCategory FUNCTIONAL_RAW_MATERIALS = new SubCategory();
                FUNCTIONAL_RAW_MATERIALS._id = 2;
                FUNCTIONAL_RAW_MATERIALS._eng_name = "FUNCTIONAL RAW MATERIALS";
                FUNCTIONAL_RAW_MATERIALS._thai_name = "FUNCTIONAL RAW MATERIALS";
                listSubCategory.Add(FUNCTIONAL_RAW_MATERIALS);

                category._subCategory = listSubCategory;
            }
            else
            {
                category._eng_name = "BASIC CHEMISCAL";
                category._thai_name = "BASIC CHEMISCAL";
                category._id = 1;
            }

            // Read Product


            
            return category;
        }

        public IList<Category> GetListCategory(int category_id)
        {
            IList<Category> categorys = new List<Category>();
            Category category = new Category();
            ReadFileService _fileService = new ReadFileService(category_id);

            IList<Product> productList = _fileService.GetProductAsyn(true).Result;

            category._product = productList;

            if (category_id == (int)Constants.FILE_NAME.SOLVENTS)
            {
                category._eng_name = "SOLVENTS & SPECIALTY";
                category._thai_name = "SOLVENTS & SPECIALTY";
                category._id = 1;

                IList<SubCategory> listSubCategory = new List<SubCategory>();
                SubCategory SOLVENTS_LIQUID_CHEMICALS = new SubCategory();
                SOLVENTS_LIQUID_CHEMICALS._id = 1;
                SOLVENTS_LIQUID_CHEMICALS._eng_name = "SOLVENTS & LIQUID CHEMICALS";
                SOLVENTS_LIQUID_CHEMICALS._thai_name = "SOLVENTS & LIQUID CHEMICALS";
                listSubCategory.Add(SOLVENTS_LIQUID_CHEMICALS);

                SubCategory FUNCTIONAL_RAW_MATERIALS = new SubCategory();
                FUNCTIONAL_RAW_MATERIALS._id = 2;
                FUNCTIONAL_RAW_MATERIALS._eng_name = "FUNCTIONAL RAW MATERIALS";
                FUNCTIONAL_RAW_MATERIALS._thai_name = "FUNCTIONAL RAW MATERIALS";
                listSubCategory.Add(FUNCTIONAL_RAW_MATERIALS);

                category._subCategory = listSubCategory;
            }
            else
            {
                category._eng_name = "BASIC CHEMISCAL";
                category._thai_name = "BASIC CHEMISCAL";
                category._id = 1;
            }
            categorys.Add(category);
            return categorys;
        }
    }
}