﻿namespace BulkyBookWeb.Models
{
    public class Category
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now; // adds a default DateTime of DateTime.Now

    }
}
