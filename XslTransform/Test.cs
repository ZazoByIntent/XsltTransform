using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XslTransform
{
    public class TestClass
    {
        private string someString;
        private List<string> settings = new List<string>();

        public TestClass() { }

        public TestClass(string someString, string someInfo)
        {
            this.someString = someString;
            this.settings.Add(someInfo);
        }
        public string SomeString
        {
            get { return someString; }
            set { someString = value; }
        }
        public List<string> Settings
        {
            get { return settings; }
            set { settings = value; }
        }
    }
}