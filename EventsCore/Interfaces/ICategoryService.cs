using System.Collections.Generic;
using EventsCore.Entities;

namespace EventsCore.Interfaces
{
    public interface ICategoryService
    {
        ServiceResult<IReadOnlyList<Category>> GetComments();

        ServiceResult<Category> GetCatogoryById(int id);

        ServiceResult<double> GetTotal();
        ServiceResult<double> GetTotalTaxes();
    }
}