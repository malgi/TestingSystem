using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingSystem.Models
{
    public class TestScheme
    {
        public int TestSchemeId { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }
        public List<ThematicField> Fields { get; set; }

        private List<TestScheme> getAvailable(ApplicationUser student)
        {
            List<TestScheme> testList = new List<TestScheme>();
            //TODO: create logic
            return testList;
        }
    }
}