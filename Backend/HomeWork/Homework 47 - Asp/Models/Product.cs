using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Globalization;

namespace Homework_47___Asp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
