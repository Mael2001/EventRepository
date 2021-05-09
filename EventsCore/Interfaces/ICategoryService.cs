using System.Collections.Generic;
using EventsCore.Entities;

namespace EventsCore.Interfaces
{
    public interface ICategoryService
    {
        ServiceResult<IReadOnlyList<Category>> GetCategories();
        ServiceResult<Category> GetCategoryById(int id);

        //ServiceResult<double> GetTotal();
        //ServiceResult<double> GetTotalTaxes();
    }
}