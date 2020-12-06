using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uxapi.Dtos
{
    public class BlogForCreationDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public string PhotoBlogUrl { get; set; }

        public IFormFile File { get; set; }

        public BlogForCreationDto()
        {
            Created = DateTime.Now;
        }

    }
}
