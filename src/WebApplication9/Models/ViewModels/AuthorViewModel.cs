using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models.ViewModels
{
    public class AuthorViewModel
    {
        [Required]
        public int Level { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string LastName { get; set; }
        [StringLength(255, MinimumLength = 5)]
        public string Occupation { get; set; }
        [StringLength(255, MinimumLength = 5)]
        public string Title { get; set; }
        [StringLength(255, MinimumLength = 5)]
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
