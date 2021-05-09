using System.Collections.Generic;
using EventsCore.Entities;
using EventsCore.Interfaces;

namespace EventsCore.Services
{
    public class CategoryService: ICategoryService
    {

        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ServiceResult<IReadOnlyList<Category>> GetCategories()
        {
            var categories = _categoryRepository.Get();
            return ServiceResult<IReadOnlyList<Category>>.SuccessResult(categories);
        }

        public ServiceResult<Category> GetCategoryById(int id)
        {
            var category = _categoryRepository.Get(id);

            if(category == null)
            {
                return ServiceResult<Category>.NotFoundResult($"No se encontro categoria con el id {id}");
            }

            return ServiceResult<Category>.SuccessResult(category);
        }

        //public ServiceResult<double> GetTotal()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public ServiceResult<double> GetTotalTaxes()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}