using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApp.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }

        [Required]
        [DisplayName("List Price")]
        [Range(1, 1000, ErrorMessage = "Range should be between 1 and 1000.")]
        public double ListPrice { get; set; }

        [Required]
        [DisplayName("Price for 1-50")]
        [Range(1, 1000, ErrorMessage = "Range should be between 1 and 1000.")]
        public double Price { get; set; }

        [Required]
        [DisplayName("Price for 50+")]
        [Range(1, 1000, ErrorMessage = "Range should be between 1 and 1000.")]
        public double Price50 { get; set; }


        [Required]
        [DisplayName("Price for 100+")]
        [Range(1, 1000, ErrorMessage = "Range should be between 1 and 1000.")]
        public double Price100 { get; set; }
    }
}
