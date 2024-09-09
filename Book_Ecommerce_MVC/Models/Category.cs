using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Ecommerce_MVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Display Order must between 1 - 100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
