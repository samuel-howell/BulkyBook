using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]  // makes Id the primary key
        public int Id { get; set; }

        [Required] // makes Name a required property
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now; // adds a default DateTime of DateTime.Now

    }
}
