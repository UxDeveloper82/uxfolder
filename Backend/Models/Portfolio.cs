using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uxapi.Models
{
    public class Portfolio
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDetails { get; set; }

        public string MyProperty { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

    }
}
