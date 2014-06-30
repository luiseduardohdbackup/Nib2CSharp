using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsTabBarProcessor : NSViewProcessor
    
    {
        public override string Name
        {
            get
            {
                return "UITabBar";
            }
            set
            {
                base.Name = value;
            }
        }

        public override string Handles
        {
            get
            {
                return "IB"+Name;
            }
            set
            {
                base.Handles = value;
            }
        }
    }
}
