using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38.Services.Products
{
    internal interface IProductsService
    {
        void CreateProduct();
        void DeleteProduct();
        void EditProduct();
        void ShowProducts();
        void FilterProducts();
        void OrderByPrice();
    }
}
