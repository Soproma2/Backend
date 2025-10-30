using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Core
{
    public class BaseEntity
    {
        private static int _currentId = 0;
        public int Id { get; private set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public BaseEntity() { }

        public void GenerateId()
        {
            Id = ++_currentId;
        }

        public static void SetLastId(int lastId)
        {
            _currentId = lastId;
        }
    }
}
