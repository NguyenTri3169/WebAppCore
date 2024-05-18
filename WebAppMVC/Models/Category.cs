using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVC.Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }
}
