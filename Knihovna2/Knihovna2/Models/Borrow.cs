using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Knihovna2.Models
{
    public class Borrow
    {
        
        public int ID { get; set; }
        public int ReaderID { get; set; }
        public int BookID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BorrowedSince { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BorrowedTo { get; set; }
       
        
        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
      
    }
}