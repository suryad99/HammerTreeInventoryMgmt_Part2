using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hammer.Data.BusinesssModel;

namespace Hammer.Data.Repository
{
    public class CategoryRepository
    {
        public List<CategoryDTO> GetCategories()
        {
            List<CategoryDTO> categoryList = new List<CategoryDTO>();
            try
            {
                using (HammerEntities entities = new HammerEntities())
                {
                    foreach (var h in entities.HammerTypes.ToList())
                    {
                        CategoryDTO dto = new CategoryDTO();
                        dto.CategoryId = h.TypeId;
                        dto.CategoryName = h.TypeName;
                        dto.CategoryDescription = h.TypeDesc;
                        categoryList.Add(dto);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return categoryList;
        }

        public CategoryDTO SaveCategory(CategoryDTO dto)
        {
            HammerType hammertype = new HammerType();
            hammertype.TypeName = dto.CategoryName;
            hammertype.TypeDesc = dto.CategoryDescription;
            try
            {
                using (HammerEntities entities = new HammerEntities())
                {
                    var newcategory = entities.HammerTypes.Add(hammertype);
                    entities.SaveChanges();
                    dto.CategoryId = newcategory.TypeId;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dto;
        }

        public bool DeleteCategory(CategoryDTO dto)
        {
            int rows = 0;
            HammerType hammertype = new HammerType();
            hammertype.TypeId = dto.CategoryId;
            try
            {
                using (HammerEntities entities = new HammerEntities())
                {
                    entities.HammerTypes.Attach(hammertype);
                    entities.HammerTypes.Remove(hammertype);
                    rows = entities.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rows > 0 ? true : false;
        }

        public CategoryDTO UpdateCategory(CategoryDTO dto)
        {
            try
            {
                using (HammerEntities entities = new HammerEntities())
                {
                    var oldhammer = entities.HammerTypes.Find(dto.CategoryId);
                    if (oldhammer != null)
                    {
                        oldhammer.TypeName = dto.CategoryName;
                        oldhammer.TypeDesc = dto.CategoryDescription;
                        entities.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dto;
        }

    }
}
