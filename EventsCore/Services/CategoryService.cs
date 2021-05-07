using System.Collections.Generic;
using EventsCore.Entities;
using EventsCore.Interfaces;

namespace EventsCore.Services
{
    public class CategoryService: ICategoryService
    {
        public ServiceResult<IReadOnlyList<Category>> GetComments()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<Category> GetCatogoryById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<double> GetTotal()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<double> GetTotalTaxes()
        {
            throw new System.NotImplementedException();
        }
    }
}