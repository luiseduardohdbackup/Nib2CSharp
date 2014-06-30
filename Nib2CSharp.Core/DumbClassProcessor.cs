using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nib2CSharp.Core
{
    class DumbClassProcessor : IClassProcessor
    {
        public override Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get; set; }

        public override string Handles
        {
            get; set; }

        
    }
}
