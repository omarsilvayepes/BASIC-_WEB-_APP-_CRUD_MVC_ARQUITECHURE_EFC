using System.ComponentModel.DataAnnotations;

namespace WebAppMVCArquitecture.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public  required string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
