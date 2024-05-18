using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    [Table("Category")]
    public class Category
    {
        public byte CategoryId { get; set; }
        public string CategoryName { get; set; }
        
    }
}
