using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        
        //public Author Author { get; set; }
        
        public int Views { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        
        //public Category Category { get; set; }
    }
}
