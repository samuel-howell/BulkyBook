using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]  // makes Id the primary key
        public int Id { get; set; }

        [Required] // makes Name a required property
        public string Name { get; set; }
        [DisplayName("Display Order")] // this data annotation allows us to use this name in our application, while referecing back to DisplayOrder for db purposes
        [Range(1,100, ErrorMessage = "You can on;y use numbers between 1 and 100")] // this data annotation forces our range to be between 1 and 100
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now; // adds a default DateTime of DateTime.Now

    }
}
