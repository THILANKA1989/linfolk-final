using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string CategoryUrl { get; set; }
        //level 0 1 2

        public ICollection<Post> Posts { get; set; }
    }
}
