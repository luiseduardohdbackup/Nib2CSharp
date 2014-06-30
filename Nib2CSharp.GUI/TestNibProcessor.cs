using System;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.GUI
{
    [Export("NIBProcessor", typeof(INIBProcessor))]
    class TestNibProcessor : INIBProcessor
    {
          //public string Name { get { return "Test Processor"; } }
        public override string Name
        {
            get { return "Test Processor"; }
        }
    }
}
