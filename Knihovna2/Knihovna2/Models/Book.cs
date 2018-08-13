using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Knihovna2.Models
{
    public class Book
    {
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Title { get; set; }
        [StringLength(50, ErrorMessage = "Genre type cannot be longer than 50 characters.")]
        public string Genre{ get; set; }
        [StringLength(50, ErrorMessage = "Author name cannot be longer than 50 characters.")]
        public string Author { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}