using HomeWork_45___Asp.Data;

namespace HomeWork_45___Asp.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly DataContext _db;
        public ProductService(DataContext db)
        {
            _db = db;
        }


    }
}
