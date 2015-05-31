using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingSystem.Models
{
    public class ThematicField
    {
        public int ThematicFieldId { get; set; }
        public String Name { get; set; }
        public List<ThematicField> ChildFields { get; set; }

        public ThematicField ParentField { get; set; }
        public List<Question> Questions { get; set; }
    }
}