using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models.ViewModels
{
    public class PostViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Content { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int Views { get; set; }
    }
}
