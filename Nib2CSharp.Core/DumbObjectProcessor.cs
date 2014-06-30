using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nib2CSharp.Core
{
    class DumbObjectProcessor : IObjectProcessor
    {
        public override string Name
        {
            get  { return "Dumb"; }
            set {; }
        }

        public override string ProcessedName
        {
            get {return "Not Implemented"; }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            return base.ProcessObject(item);
        }
    }
}
