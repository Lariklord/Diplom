﻿namespace Diplom.Models
{
    public class Category
    {
        public Category() { }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MainUrl { get; set; }
        public string? SideUrl { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
