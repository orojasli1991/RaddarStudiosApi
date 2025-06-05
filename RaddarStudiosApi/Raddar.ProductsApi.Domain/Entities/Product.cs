using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raddar.ProductsApi.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0.01, double.MaxValue,ErrorMessage ="el precio debe ser mayor a cero")]
        public decimal Price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "el stock debe ser mayor a cero")]
        public int Stock { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
