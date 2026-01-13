using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.Product
{
    internal interface IProductService
    {
        void ViewAllProducts();
        void SearchProducts();
        void FilterByCategory();
        void ViewProductDetails();
        void AddProduct();
        void UpdateProduct();
        void DeleteProduct();
        void ViewCategories();
    }
}
