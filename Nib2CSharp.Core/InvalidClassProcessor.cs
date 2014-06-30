using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nib2CSharp.Core
{
    class InvalidClassProcessor : IClassProcessor
    {
        public override Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { return "// Invalid Class"; }
            set {}
        }
        public override string Handles
        {
            get; set; }

        public override string AddChild(string parentName, string childname, string s = null)
        {
            return "// Invalid Class";
        }

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
           Console.WriteLine("//Invalid Class");
        }

        public override string ConstructorString()
        {
            return "// Invalid Class";
        }

        public override Dictionary<string, string> ProcessObject(System.Xml.Linq.XElement anObject)
        {
            return new Dictionary<string, string>() {{"__Helper__Class__", "__Invalid__"}};
        }
        
    }
}
