using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public CuisineType CuisineType { get; set; }
    }
}
