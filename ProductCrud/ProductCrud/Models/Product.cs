using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCrud.Models
{
    public class Product
    {
        [Key]
        public long ID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class ProductViewModel
    {
        public long ID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductCreateModel
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductEditModel
    {
        public long ID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
