using System;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("NIBProcessor",typeof(INIBProcessor))]
    class NibProcessor : INIBProcessor
    {
          //public  string Name { get { return "iOS"; } }

          public override string Name
          {
              get { return "iOS"; }
          }
    }
}
