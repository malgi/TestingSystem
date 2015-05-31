using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingSystem.Models
{
    public class StudentGroup
    {
        public int StudentGroupId { get; set; }
        public string Name { get; set; }
        public List<ApplicationUser> Students { get; set; }
        public string Code { get; set; }
    }
}