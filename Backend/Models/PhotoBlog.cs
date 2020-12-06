using System;

namespace uxapi.Models
{
    public class PhotoBlog
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        public Blog Blog { get; set; }

        public int BlogId { get; set; }
    }
}