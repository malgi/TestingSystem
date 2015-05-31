using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingSystem.Models
{
    public class TestResult
    {
        public int TestResultId { get; set; }
        public int Points { get; set; }
        public ApplicationUser Student { get; set; }
        public TestScheme TestScheme { get; set; }
    }
    
}