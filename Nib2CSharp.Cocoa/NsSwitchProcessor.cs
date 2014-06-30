using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsSwitchProcessor : NsControlProcessor
    {
          public override string Name
          {
              get
              {
                  return "UISwitch";
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
                  return "IBUISwitch";
              }
              set
              {
                  base.Handles = value;
              }
          }
          public override void ProcessKey(System.Xml.Linq.XElement item)
          {
              if (item.Value == "on")
              {
                  output["On"] = item.Parent.GetElementForKey("on").Value.BooleanString();
              }
              else
              base.ProcessKey(item);
          }
    }
}
